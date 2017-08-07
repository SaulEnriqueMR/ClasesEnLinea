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
    /// Lógica de interacción para ImpartirEE.xaml
    /// </summary>
    public partial class ImpartirEE : Window
    {
        public List<TExperienciaEducativa> ExperienciasEducativas { set; get; }
        public TCuenta CuentaIniciada { set; get; }

        public ImpartirEE(TCuenta cuentaIniciada)
        {
            InitializeComponent();
            CuentaIniciada = cuentaIniciada;
            try
            {
                ExperienciasEducativas = Conexion.ExperienciaEducativaServiceCliente.obtenerEE();
                var tEEVacia = new TExperienciaEducativa
                {
                    IdExperienciaEducativa = 0,
                    Nombre = "Vacio",
                };

                TExperienciaEducativa tEEError = new TExperienciaEducativa
                {
                    IdExperienciaEducativa = 0,
                    Nombre = "Error",
                };

                if (!ExperienciasEducativas.Contains(tEEVacia) && !ExperienciasEducativas.Contains(tEEError))
                {
                    LlenarComboBox();
                }
                else
                {
                    BtnImpartir.IsEnabled = false;
                    if (ExperienciasEducativas.Contains(tEEVacia))
                    {
                        TxtBlProblema.Text = "No hay experiencias educativas";
                    }
                    else
                    {
                        TxtBlProblema.Text = "No se pudieron recuperar Experiencias Educativas";
                    }
                    TxtBlProblema.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                MessageBox.Show("No se pudo conectar al servidor, intente más tarde");
                Conexion.EstaConectado = false;
                Conexion.Conectar();
            }
        }

        public void LlenarComboBox()
        {
            CbBxExperiencias.DisplayMemberPath = "Nombre";
            CbBxExperiencias.SelectedValuePath = "IdExperienciaEducativa";
            CbBxExperiencias.ItemsSource = ExperienciasEducativas;
        }

        private void BtnImpartir_Click(object sender, RoutedEventArgs e)
        {
            if (CbBxExperiencias.SelectedIndex > -1)
            {
                try
                {
                    var idExperienciaEducativa = Int32.Parse(CbBxExperiencias.SelectedValue.ToString());
                    var idCuentaIniciada = CuentaIniciada.IdCuenta;
                    TEEImpartida eeImpartida = new TEEImpartida
                    {
                        IdCuenta = idCuentaIniciada,
                        IdEE = idExperienciaEducativa
                    };
                    string resultadoRegistro = Conexion.ExperienciaEducativaServiceCliente.registrarEEParaImpartir(eeImpartida);
                    if (resultadoRegistro.Equals("EEIRegistrada"))
                    {
                        MessageBox.Show("Experiencia Educativa para Impartir registrada");
                        Close();
                    }
                    else
                    {
                        if (resultadoRegistro.Equals("EEIDuplicada"))
                        {
                            MessageBox.Show("Ya imparte esta Experiencia Educativa");
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al registrar Experiencia Educativa para Impartir, intente más tarde");
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

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal(CuentaIniciada);
            menuPrincipal.Show();
        }
    }
}
