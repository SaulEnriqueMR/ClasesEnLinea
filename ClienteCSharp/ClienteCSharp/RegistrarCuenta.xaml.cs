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
using Thrift.Protocol;
using Thrift.Transport;
using ThriftServices;
using ThriftStructs;

namespace ClienteCSharp
{
    /// <summary>
    /// Lógica de interacción para RegistrarCuenta.xaml
    /// </summary>
    public partial class RegistrarCuenta : Window
    {

        public RegistrarCuenta()
        {
            InitializeComponent();
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

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if(!HayCamposVacios())
            {
                try
                {
                    var nombre = TxtBxNombre.Text;
                    var usuario = TxtBxUsuario.Text;
                    var contrasena = PwdBxContrasena.Password;
                    var contrasenaCifrada = Utilidad.CifrarContrasena(contrasena);
                    TCuenta nuevaCuenta = new TCuenta
                    {
                       Nombre = nombre,
                       Usuario = usuario,
                       Contrasena = contrasenaCifrada
                    };
                    var resultadoRegistro = Conexion.CuentaServiceCliente.registrarCuenta(nuevaCuenta);
                    if (resultadoRegistro.Equals("CuentaRegistrada"))
                    {
                        MessageBox.Show("La cuenta ha sido registrada con éxito");
                        Close();
                    }
                    else
                    {
                        if (resultadoRegistro.Equals("CuentaRepetida"))
                        {
                            MessageBox.Show("Ya hay una cuenta con ese nombre o ese usuario");
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al registrar cuenta, intente más tarde");
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

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public bool HayCamposVacios()
        {
            var nombre = TxtBlNombre.Text;
            var usuario = TxtBxUsuario.Text;
            var contrasena = PwdBxContrasena.Password;

            //Verifica que la información no sea vacía
            if (nombre.Equals("") || usuario.Equals("") || contrasena.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
