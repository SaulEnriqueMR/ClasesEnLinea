using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThriftStructs;

namespace ClienteCSharp
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public TCuenta CuentaIniciada { set; get; }
        List<TEEAsistenciaView> ExperienciasAsistencia { set; get; }
        List<TEEImpartidaView> ExperienciasImpartidas { set; get; }
        List<EEParaMostrar> EESParaMostar { set; get; }

        partial class EEParaMostrar
        {
            public int IdImpartida { set; get; }
            public string Detalles { set; get; }
        }

        public MenuPrincipal(TCuenta cuentaIniciada)
        {
            InitializeComponent();
            CuentaIniciada = cuentaIniciada;
            TxtBlNombre.Text = CuentaIniciada.Nombre;
            EESParaMostar = new List<EEParaMostrar>();
            try
            {

                ExperienciasAsistencia = Conexion.ExperienciaEducativaServiceCliente.obtenerEEAsistencia(CuentaIniciada.IdCuenta);
                ExperienciasImpartidas = Conexion.ExperienciaEducativaServiceCliente.obtenerEEImpartidas(CuentaIniciada.IdCuenta);
                LlenarLista();
            }
            catch(Exception)
            {
                MessageBox.Show("Error con el servidor, intente más tarde");
            }
        }

        private void LlenarLista()
        {
            var tEEIError = new TEEImpartidaView
            {
                IdEEImpartida = 0,
                Ee = "Error",
                Maestro = "Error",
                IdCuenta = 0
            };
            var tEEAError = new TEEAsistenciaView
            {
                IdCuenta = 0,
                IdEEImpartida = 0,
                Ee = "Error",
                Maestro = "Error"
            };

            if (ExperienciasImpartidas.Contains(tEEIError) || ExperienciasAsistencia.Contains(tEEAError))
            {
                TxtBlProblema.Text = "Hubo problemas al recuperar algunas de sus Experiencias Educativas, intente más tarde";
                TxtBlProblema.Visibility = Visibility.Visible;
            }

            EEParaMostrar eeParaMostrar;
            foreach (var eei in ExperienciasImpartidas)
            {
                if (eei.IdCuenta > 0)
                {
                    eeParaMostrar = new EEParaMostrar();
                    eeParaMostrar.IdImpartida = eei.IdEEImpartida;
                    eeParaMostrar.Detalles = "Impartes: " + eei.Ee;
                    EESParaMostar.Add(eeParaMostrar);
                }
            }
            foreach (var eea in ExperienciasAsistencia)
            {
                if (eea.IdCuenta > 0)
                {
                    eeParaMostrar = new EEParaMostrar();
                    eeParaMostrar.IdImpartida = eea.IdEEImpartida;
                    eeParaMostrar.Detalles = "Asistes a: " + eea.Ee + " impartida por: " + eea.Maestro;
                    EESParaMostar.Add(eeParaMostrar);
                } 
            }

            LstBxEEImpartidas.DisplayMemberPath = "Detalles";
            LstBxEEImpartidas.SelectedValuePath = "IdImpartida";
            LstBxEEImpartidas.ItemsSource = EESParaMostar;
        }

        private void TxtBlRegistrarEE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrarExperienciaEducativa registrarEE = new RegistrarExperienciaEducativa(CuentaIniciada);
            registrarEE.Show();
            Close();
        }

        private void BtnImpartirEE_Click(object sender, RoutedEventArgs e)
        {
            ImpartirEE impartirEE = new ImpartirEE(CuentaIniciada);
            impartirEE.Show();
            Close();
        }

        private void BtnAsistirEE_Click(object sender, RoutedEventArgs e)
        {
            AsistirEE asistirEE = new AsistirEE(CuentaIniciada);
            asistirEE.Show();
            Close();
        }

        private void TxtBlSalir_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void LstBxEEImpartidas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var idSalon = Int32.Parse(LstBxEEImpartidas.SelectedValue.ToString());
            try
            {
                var resultadoUnirseSalon = Conexion.SalonDeClasesServiceCliente.abrirSalon(CuentaIniciada.IdCuenta, idSalon);
                if(resultadoUnirseSalon.Equals("ExitoAbrirSalon") || resultadoUnirseSalon.Equals("SalonAbierto"))
                {
                    if (resultadoUnirseSalon.Equals("ExitoAbrirSalon"))
                    {
                        Salon salon = new Salon(CuentaIniciada, idSalon, "Maestro");
                        salon.Show();
                        Close();
                    }
                    else
                    {
                        Salon salon = new Salon(CuentaIniciada, idSalon, "Alumno");
                        salon.Show();
                        Close();
                    }   
                }
                else
                {
                    MessageBox.Show("El salón está vacío y no eres un maestro para abrir este salón");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
