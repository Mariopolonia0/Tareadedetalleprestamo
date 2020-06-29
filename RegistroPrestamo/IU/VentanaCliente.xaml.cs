using RegistroPrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroPrestamo.BLL;
using RegistroPrestamo.DAL;

namespace RegistroPrestamo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class VentanaCliente : Window
    {
        public VentanaCliente()
        {
            InitializeComponent();
        }
        private Cliente cliente = new Cliente();
        private void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
             if (IdTextBox.Text.Length == 0 | NombreTextBox.Text.Length == 0 | TelefonoTextBox.Text.Length == 0 | CedulaTextBox.Text.Length == 0 | DirecionTextBox.Text.Length == 0 | FechaTextBox.Text.Length == 0)
             {
                 MessageBox.Show("Campo Imcompleto", "Mensaje De Error", MessageBoxButton.OK, MessageBoxImage.Information);
                 return;
             }
             
            cliente.id = Convert.ToInt32(IdTextBox.Text);
            cliente.nombre = NombreTextBox.Text.ToString();
            cliente.telefono = TelefonoTextBox.Text.ToString();
            cliente.cedula = CedulaTextBox.Text.ToString();
            cliente.direcion = DirecionTextBox.Text.ToString();
            cliente.fecha = Convert.ToDateTime(FechaTextBox.Text);
           // RegistroBLL.GuardarCliente(cliente);
            Contexto contexto = new Contexto();

            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();
            MessageBox.Show("Se Guardo Correctamente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }
}
