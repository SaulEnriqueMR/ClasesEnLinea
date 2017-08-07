using Aspose.Slides;
using AvCapWPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using ThriftCallbacks;
using ThriftStructs;

namespace ClienteCSharp
{
    /// <summary>
    /// Lógica de interacción para Salon.xaml
    /// </summary>
    public partial class Salon : Window, ChatCallback.Iface, SalonDeClasesCallback.Iface, PresentacionCallback.Iface
    {
        public TCuenta CuentaIniciada { set; get; }
        public string DireccionMaestro { set; get; }
        public int IdSalon { set; get; }
        public string Rol { set; get; }
        //public ObservableCollection<string> UsuariosConectados = new ObservableCollection<string>();
        private CallbackService Callback;
        public string UbicacionArchivoParaEnviar = @"..\..\..\paraenviar\";
        public string UbicacionArchivosSVG = @"..\..\..\svg\";
        public VisorDiapositivas Visor { set; get; }
        public List<string> DiapositivasRecibidas { set; get; }
        //public Dictionary<int, string> DiapositivasRecibidas { set; get; }
        public int DiapositivaActiva { set; get; }
        public Window1 Camara { set; get; }

        partial class CallbackService
        {
            public SalonDeClasesCallback.Processor ProcessorSalon { set; get; } 
            public ChatCallback.Processor ProcessorChat { set; get; }
            public PresentacionCallback.Processor ProcessorPresentacion { set; get; }
            public TMultiplexedProcessor Processor { set; get; }
            public TServerTransport Transporte { set; get; }
            public TServer Servidor { set; get; }

            public CallbackService(Salon handlerSalon, Salon handlerChat, Salon handlerPresentacion)
            {
                ProcessorSalon = new SalonDeClasesCallback.Processor(handlerSalon);
                ProcessorChat = new ChatCallback.Processor(handlerChat);
                ProcessorPresentacion = new PresentacionCallback.Processor(handlerPresentacion);

                Processor = new TMultiplexedProcessor();

                Processor.RegisterProcessor(nameof(SalonDeClasesCallback), ProcessorSalon);
                Processor.RegisterProcessor(nameof(ChatCallback), ProcessorChat);
                Processor.RegisterProcessor(nameof(PresentacionCallback), ProcessorPresentacion);

                Transporte = new TServerSocket(9091);
                Servidor = new TThreadPoolServer(Processor, Transporte);
                //servidor.Serve();
            }

            public void CorrerCallback()
            {
                Servidor.Serve();
            }

            public void DetenerCallback()
            {
                Servidor.Stop();
            }
        }


        public Salon(TCuenta cuentaIniciada, int idSalon, string rol)
        {
            try
            {
                DataContext = this;
                InitializeComponent();
                CuentaIniciada = cuentaIniciada;
                IdSalon = idSalon;
                Rol = rol;
                FuncionalidadDependiendoRol();
                var levantarCallback = new Thread(new ThreadStart(LevantarCallback));
                levantarCallback.Start();
                ConectarAlServicio();
                Visor = new VisorDiapositivas(rol, IdSalon);
            }
            catch(Exception)
            {
                MessageBox.Show("Hubo un error al intentar conectar");
            }
        }

        public void ConectarAlServicio()
        {
            var direccionIP = Utilidad.ObtenerDireccionIP();
            TConexion tNuevConexion = new TConexion
            {
                IdCuenta = CuentaIniciada.IdCuenta,
                IdSalon = IdSalon,
                Nombre = CuentaIniciada.Nombre,
                //DireccionIP = "localhost",
                DireccionIP = direccionIP
            };
            string resultadoUnirse = Conexion.SalonDeClasesServiceCliente.unirseSalon(tNuevConexion);
            if (resultadoUnirse.Equals("ExitoUnirMaestro") || resultadoUnirse.Equals("ExitoUnirAlumno"))
            {
                MensajeDeBienvenida();
            }
            else
            {
                MessageBox.Show("No se pudo entrar al salón, intente más tarde");
            }
        }

        public void MensajeDeBienvenida()
        {
            TxtBxChat.Text = TxtBxChat.Text + CuentaIniciada.Nombre;
            var nuevoMensaje = new TMensaje
            {
                IdSalon = IdSalon,
                Contenido = "¡Me he unido a la sesión!",
                NombreRemitente = CuentaIniciada.Nombre
            };
            Conexion.ChatServiceCliente.enviarMensaje(nuevoMensaje);
        }

        public void LevantarCallback()
        {
            Callback = new CallbackService(this, this, this);
            Callback.CorrerCallback();
        }

        public void FuncionalidadDependiendoRol()
        {
            if (!Rol.Equals("Maestro"))
            {
                LstBxConectados.IsEnabled = false;
                //Se deshabilita la opción de stream
                TxtBlInstruccionDiapositiva.Visibility = Visibility.Collapsed;
                TxtBxNombreArchivo.Visibility = Visibility.Collapsed;
                BtnEnviarDiapositivas.Visibility = Visibility.Collapsed;
                DiapositivasRecibidas = new List<string>();
            }
            else
            {
                Camara = new Window1();
                Camara.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Conexion.SalonDeClasesServiceCliente.salirSalon(IdSalon, CuentaIniciada.IdCuenta);
            Callback.DetenerCallback();
            Visor.Close();
            if (Rol.Equals("Maestro"))
            {
                Camara.Close();
            }
            MenuPrincipal menuPrincipal = new MenuPrincipal(CuentaIniciada);
            menuPrincipal.Show();
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            var contenidoMensaje = TxtBxMensaje.Text;
            if (!TxtBxMensaje.Text.Equals(""))
            {
                var nuevoMensaje = new TMensaje
                {
                    IdSalon = IdSalon,
                    Contenido = contenidoMensaje,
                    NombreRemitente = CuentaIniciada.Nombre
                };
                Conexion.ChatServiceCliente.enviarMensaje(nuevoMensaje);
                TxtBxMensaje.Text = "";
            }
        }

        public void actualizarConectados(List<string> conectados)
        {
            LstBxConectados.Dispatcher.BeginInvoke(new Action<List<string>>((usuariosParaMostrar) =>
            {
                LstBxConectados.Items.Clear();
                foreach (var conectado in usuariosParaMostrar)
                {
                    LstBxConectados.Items.Add(conectado);
                }
            }), new object[] { conectados });

        }

        public void recibirDireccionMaestro(string direccionIPMaestro)
        {
            DireccionMaestro = direccionIPMaestro;
        }

        public void enExpulsion()
        {
            MessageBox.Show("Debido a tu comportamiento, el maestro te ha expulsado de su clase");
            Close();
        }

        public void recibirMensaje(TMensaje mensajeRecibido)
        {
            string mensaje = mensajeRecibido.NombreRemitente + " dice: " + mensajeRecibido.Contenido;
            TxtBxChat.Dispatcher.BeginInvoke(new Action<string>((mensajeParaAgregar) =>
            {
                TxtBxChat.AppendText("\n" + mensajeParaAgregar);
                TxtBxChat.ScrollToEnd();
            }), new object[] { mensaje });
        }

        private void LstBxConectados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var elementoSeleccionado = LstBxConectados.SelectedItem;
            if (elementoSeleccionado != null)
            {
                var usuarioSeleccionado = elementoSeleccionado.ToString();
                Conexion.SalonDeClasesServiceCliente.expulsar(IdSalon, CuentaIniciada.IdCuenta, usuarioSeleccionado);
            }
        }

        public int ConvertirDiapositivasASVG(string nombreDiapositivas)
        {
            string rutaArchivoParaConvertir = UbicacionArchivoParaEnviar + nombreDiapositivas + ".pptx";
            string rutaArchivoConvertido = UbicacionArchivosSVG + nombreDiapositivas;

            int numeroDiapositivas = 0;

            using (Presentation pres = new Presentation(rutaArchivoParaConvertir))
            {
                numeroDiapositivas = pres.Slides.Count;
                for (var i = 0; i < numeroDiapositivas; i++)
                {
                    ISlide sld = pres.Slides[i];

                    MemoryStream SvgStream = new MemoryStream();

                    sld.WriteAsSvg(SvgStream);
                    SvgStream.Position = 0;

                    using (Stream fileStream = File.OpenWrite(rutaArchivoConvertido + i + ".svg"))
                    {
                        byte[] buffer = new byte[8 * 1024];
                        int len;
                        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, len);
                        }

                    }
                    SvgStream.Close();
                }
            }
            return numeroDiapositivas;
        }

        public List<string> LeerTodosSVG(int numeroDiapositivas, string nombreArchivos)
        {
            string nombreSVGS;
            var archivosLeidos = new List<string>();
            for (var i = 0; i < numeroDiapositivas; i++)
            {
                nombreSVGS = UbicacionArchivosSVG + nombreArchivos + i + ".svg";
                var leerArchivo = File.ReadAllText(nombreSVGS);
                archivosLeidos.Add(leerArchivo);
            }
            return archivosLeidos;
        }

        public void recibirPresentacion(TPresentacion tPresentacion)
        {
            DiapositivasRecibidas = tPresentacion.Diapositiva;
            DiapositivaActiva = 0;
            var diapositiva = DiapositivasRecibidas.ElementAt(0);
            Visor.WBsrVisor.Dispatcher.BeginInvoke(new Action<string>((diapositivaParaMostrar) =>
            {
                Visor.Show();
                Visor.MostrarDiapositiva(diapositivaParaMostrar, 0);
            }), new object[] { diapositiva });
        }

        public void enAvanzarDiapositiva()
        {
            DiapositivaActiva = DiapositivaActiva + 1;
            var diapositiva = DiapositivasRecibidas.ElementAt(DiapositivaActiva);
            Visor.WBsrVisor.Dispatcher.BeginInvoke(new Action<string>((diapositivaParaMostrar) =>
            {
                Visor.Show();
                Visor.MostrarDiapositiva(diapositivaParaMostrar, DiapositivaActiva);
            }), new object[] { diapositiva });
        }

        public void enRegresarDiapositiva()
        {
            DiapositivaActiva = DiapositivaActiva - 1;
            var diapositiva = DiapositivasRecibidas.ElementAt(DiapositivaActiva);
            Visor.WBsrVisor.Dispatcher.BeginInvoke(new Action<string>((diapositivaParaMostrar) =>
            {
                Visor.Show();
                Visor.MostrarDiapositiva(diapositivaParaMostrar, DiapositivaActiva);
            }), new object[] { diapositiva });
        }

        private void BtnEnviarDiapositivas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!TxtBxNombreArchivo.Text.Equals(""))
                {
                    Cursor = Cursors.Wait;
                    BtnEnviarDiapositivas.IsEnabled = false;
                    TxtBxNombreArchivo.IsEnabled = false;
                    var nombreArchivo = TxtBxNombreArchivo.Text;
                    var numeroDiapositivas = ConvertirDiapositivasASVG(nombreArchivo);
                    Visor.Diapositivas = LeerTodosSVG(numeroDiapositivas, nombreArchivo);
                    var diapositivas = new TPresentacion
                    {
                        IdSalon = IdSalon,
                        Diapositiva = Visor.Diapositivas
                    };
                    Conexion.PresentacionServiceCliente.enviarPresentacion(diapositivas);
                    Cursor = Cursors.Arrow;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Verifique que el nombre haya sido ingresado correctamente (ingrese solamente nombre, sin terminación)");
            }
        }
    }
}
