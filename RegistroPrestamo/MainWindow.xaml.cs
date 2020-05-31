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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Prestamo prestamo = new Prestamo();

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {

            
            Contexto contexto = new Contexto();
            /* prestamo.idPestamo = Convert.ToInt32(IdPrestamo_TextBox.Text);
             prestamo.fecha = Convert.ToDateTime(Fecha_TextBox.Text);
             prestamo.idpersona = Convert.ToInt32(IdPersona_TextBox.Text);*/
             prestamo.concepto = Convert.ToDouble(Concepto_TextBox.Text);
             prestamo.monto = Convert.ToDouble(Monto_TextBox.Text);
             //prestamo.concepto = prestamo.concepto * -1;

             double dividiendo = (0.01 * prestamo.monto);
             double divisor = Math.Pow(prestamo.concepto, -0.01 );
             //divisor = Math.Round(divisor, 2);
                
             prestamo.Balance = divisor;
            
            
            contexto.Prestamos.Add(prestamo);
           // Balance_TextBox
             contexto.SaveChanges();

            MessageBox.Show("Guardado ", "Con Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            /*  if (paso)
              {
                  MessageBox.Show("Guardado ", "Con Exito", MessageBoxButton.OK, MessageBoxImage.Information);
              }
              else
              {
                  MessageBox.Show("Guardado ", "No Se Realizo", MessageBoxButton.OK, MessageBoxImage.Information);
              }
            */

        }

        public bool Validar()
        {
            bool esValido = new bool();
            if (IdPrestamo_TextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("No Hay Dato Ingresado"," Revise El Folmulario",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            return esValido;
        }

        
    }
}
