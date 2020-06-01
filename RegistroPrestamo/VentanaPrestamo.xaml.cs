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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistroPrestamo.Entidades;
using RegistroPrestamo.BLL;
using RegistroPrestamo.DAL;
namespace RegistroPrestamo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VentanaPrestamo: Window
    {
        public VentanaPrestamo()
        {
            InitializeComponent();
        }
        private Prestamo prestamo = new Prestamo();

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            
             if (IdPrestamo_TextBox.Text.Length == 0  | Fecha_TextBox.Text.Length == 0 | IdPersona_TextBox.Text.Length == 0 | Concepto_TextBox.Text.Length == 0 | Monto_TextBox.Text.Length ==0)
            {
                MessageBox.Show("Campo Imcompleto", "Mensaje De Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            prestamo.idPestamo = Convert.ToInt32(IdPrestamo_TextBox.Text);
            prestamo.fecha = Convert.ToDateTime(Fecha_TextBox.Text);
            prestamo.idpersona = Convert.ToInt32(IdPersona_TextBox.Text);
            prestamo.concepto = Convert.ToDouble(Concepto_TextBox.Text);
            prestamo.monto = Convert.ToDouble(Monto_TextBox.Text);
            Balance_TextBox.Text = RegistroBLL.Guardar(prestamo).ToString();
            MessageBox.Show("Se Guardo Correctamente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

       

        
    }
}
