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

namespace ClienteCSharp
{
    /// <summary>
    /// Lógica de interacción para VisorDiapositivas.xaml
    /// </summary>
    public partial class VisorDiapositivas : Window
    {
        public int IdSalon { set; get; }
        public List<string> Diapositivas { set; get; }
        public int NoDeDiapositiva { set; get; }

        public VisorDiapositivas(string rol, int idSalon)
        {
            InitializeComponent();
            IdSalon = idSalon;
            if (!rol.Equals("Maestro"))
            {
                BtnAvanzar.IsEnabled = false;
                BtnRegresar.IsEnabled = false;
            }

        }

        public void MostrarDiapositiva(string diapositiva, int noDiapositiva)
        {
            NoDeDiapositiva = NoDeDiapositiva;
            WBsrVisor.NavigateToString(diapositiva);
        }

        private void BtnAvanzar_Click(object sender, RoutedEventArgs e)
        {
            if(NoDeDiapositiva < Diapositivas.Count)
            {
                Conexion.PresentacionServiceCliente.avanzarDiapositiva(IdSalon);
            }
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            if(NoDeDiapositiva <= 0)
            {
                Conexion.PresentacionServiceCliente.regresarDiapositiva(IdSalon);
            }
        }
    }
}
