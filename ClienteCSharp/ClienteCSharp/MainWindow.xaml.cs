using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Thrift.Protocol;
using Thrift.Transport;
using ThriftServices;
using ThriftStructs;

namespace ClienteCSharp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Constructor de la ventana MainWindow.xaml que a su vez también es la primera ventana que se muestra del sistema 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            if (!Conexion.EstaConectado)
            {
                try
                {
                    Conexion.Conectar();
                }
                catch(Exception)
                {
                    MessageBox.Show("No se pudo conectar al servidor, intente más tarde");
                    Conexion.EstaConectado = false;
                }
            }
        }

        /// <summary>
        /// Valida la información ingresada antes del registro
        /// </summary>
        /// <param name="usuario">Se verifica si lo contenido en el text box usuario contiene texto</param>
        /// <param name="contrasena">Se verifica si lo contenido en el text box contraseña contiene texto</param>
        /// <returns>Regresa verdadero o falso dependiendo si hay campos vacíos</returns>
        public bool HayCamposVacios()
        {
            var usuario = TxtBxUsuario.Text;
            var contrasena = PwdBxContrasena.Password;
            //Verifica que la información no sea vacía
            if (usuario.Equals("") || contrasena.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Interacción lógica que ocurre cuando se selecciona la opción Registrarse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtblRegistrarse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Se crea una nueva ventana RegistrarJugardor, con parámetro de lenguaje que está configurado.
            RegistrarCuenta registrar = new RegistrarCuenta();
            //Se muestra la ventana de Registrar Jugador
            registrar.Show();
            //Se cierra esta ventana
            Close();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            
            if(!HayCamposVacios())
            {
                try
                {
                    var usuario = TxtBxUsuario.Text;
                    var contrasena = PwdBxContrasena.Password;
                    var contrasenaCifrada = Utilidad.CifrarContrasena(contrasena);
                    TCuenta cuentaIniciada = Conexion.CuentaServiceCliente.iniciarSesion(usuario, contrasenaCifrada);
                    if (cuentaIniciada.IdCuenta > 0)
                    {
                        MenuPrincipal menuPrincipal = new MenuPrincipal(cuentaIniciada);
                        menuPrincipal.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrectos");
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
    }
}
