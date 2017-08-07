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
    /// Lógica de interacción para RegistrarExperienciaEducativa.xaml
    /// </summary>
    public partial class RegistrarExperienciaEducativa : Window
    {
        public TCuenta CuentaIniciada { set; get; }

        public RegistrarExperienciaEducativa(TCuenta cuentaIniciada)
        {
            InitializeComponent();
            CuentaIniciada = cuentaIniciada;
            if (!Conexion.EstaConectado)
            {
                try
                {
                    Conexion.Conectar();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo conectar al servidor, intente más tarde");
                    Conexion.EstaConectado = false;
                }
            }
        }

        private void BtnRegistrarEE_Click(object sender, RoutedEventArgs e)
        {
            if(!HayCamposVacios())
            {
                try
                {
                    var nombreEE = TxtBxNombreEE.Text;
                    var ee = new TExperienciaEducativa
                    {
                        Nombre = nombreEE
                    };
                    var resultadoRegistro = Conexion.ExperienciaEducativaServiceCliente.registrarEE(ee);
                    if (resultadoRegistro.Equals("EERegistrada"))
                    {
                        MessageBox.Show("Experiencia Educativa registrada");
                        Close();
                    }
                    else
                    {
                        if (resultadoRegistro.Equals("EEDuplicada"))
                        {
                            MessageBox.Show("Ya hay una Experiencia Educativa con ese nombre");
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al registrar Experiencia Educativa, intente más tarde");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo conectar al servidor, intente más tarde");
                    Conexion.EstaConectado = false;
                    Conexion.Conectar();
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacíos, por favor verifique que haya ingresado la informacion solicitada");
            }
        }

        public bool HayCamposVacios()
        {
            if (TxtBxNombreEE.Text.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal(CuentaIniciada);
            menuPrincipal.Show();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
