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
    /// Lógica de interacción para AsistirEE.xaml
    /// </summary>
    public partial class AsistirEE : Window
    {
        TCuenta CuentaIniciada { set; get; }
        List<TEEImpartidaView> ExperienciasImpartidas { set; get; }
        List<EEIParaMostrar> EEISParaMostrar { set; get; }

        partial class EEIParaMostrar{
            public string Descripcion { set; get; }
            public int IdEEI { set; get; }
        }

        public AsistirEE(TCuenta cuentaIniciada)
        {
            InitializeComponent();
            EEISParaMostrar = new List<EEIParaMostrar>();
            CuentaIniciada = cuentaIniciada;
            try
            {
                ExperienciasImpartidas = Conexion.ExperienciaEducativaServiceCliente.obtenerTodasEEImpartidas(cuentaIniciada.IdCuenta);
                var tEEVacia = new TEEImpartidaView
                {
                    IdEEImpartida = 0,
                    Ee = "Vacio",
                    Maestro = "Vacio",
                    IdCuenta = 0,
                };

                var tEEError = new TEEImpartidaView
                {
                    IdEEImpartida = 0,
                    Ee = "Error",
                    Maestro = "Error",
                    IdCuenta = 0,
                };
                if (!ExperienciasImpartidas.Contains(tEEVacia) && !ExperienciasImpartidas.Contains(tEEError))
                {
                    LlenarComboBox();
                }
                else
                {
                    BtnAsistir.IsEnabled = false;
                    if (ExperienciasImpartidas.Contains(tEEVacia))
                    {
                        TxtBlProblema.Text = "No hay experiencias educativas impartidas";
                    }
                    else
                    {
                        TxtBlProblema.Text = "No se pudieron recuperar Experiencias Educativas impartidas";
                    }
                    TxtBlProblema.Visibility = Visibility.Visible;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No se pudo conectar con el servidor, intente más tarde");
                Conexion.EstaConectado = false;
                Conexion.Conectar();
            }
        }

        public void LlenarComboBox()
        {
            EEIParaMostrar impartida;
            foreach (var eei in ExperienciasImpartidas)
            {
                impartida = new EEIParaMostrar();
                impartida.Descripcion = eei.Ee + " impartida por: " + eei.Maestro;
                impartida.IdEEI = eei.IdEEImpartida;
                EEISParaMostrar.Add(impartida);
            }
            CbBxExperienciasImpartidas.DisplayMemberPath = "Descripcion";
            CbBxExperienciasImpartidas.SelectedValuePath = "IdEEI";
            CbBxExperienciasImpartidas.ItemsSource = EEISParaMostrar;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal(CuentaIniciada);
            menuPrincipal.Show();
        }

        private void BtnAsistir_Click(object sender, RoutedEventArgs e)
        {
            if (CbBxExperienciasImpartidas.SelectedIndex > -1)
            {
                try
                {
                    var idExperienciaImpartida = Int32.Parse(CbBxExperienciasImpartidas.SelectedValue.ToString());
                    var idCuentaIniciada = CuentaIniciada.IdCuenta;
                    TEEAsistencia eeAsistencia = new TEEAsistencia
                    {
                        Idcuenta = idCuentaIniciada,
                        Ideeimpartida = idExperienciaImpartida
                    };
                    string resultadoRegistro = Conexion.ExperienciaEducativaServiceCliente.registrarEEParaAsistir(eeAsistencia);
                    if (resultadoRegistro.Equals("EEARegistrada"))
                    {
                        MessageBox.Show("Experiencia Educativa para asistir registrada");
                        Close();
                    }
                    else
                    {
                        if (resultadoRegistro.Equals("EEARepetida"))
                        {
                            MessageBox.Show("Ya asistes a esta Experiencia Educativa");
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al registrar Experiencia Educativa para asistir, intente más tarde");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo conectar al servidor, intente más tarde");
                    Conexion.EstaConectado = false;
                    Conexion.Conectar();
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una Experiencia Educativa para impartir");
            }
        }
    }
}
