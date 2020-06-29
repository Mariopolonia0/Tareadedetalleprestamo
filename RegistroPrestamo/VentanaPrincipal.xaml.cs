using RegistroPrestamo.IU;
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

namespace RegistroPrestamo
{
    /// <summary>
    /// Interaction logic for VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
            UsuarioTextBox.Text = "Mario";
            ContrasenaTextBox.Text = "******";
        }

        private void RegistroPrestamo_Click(object sender, RoutedEventArgs e)
        {
            VentanaPrestamo ventana = new VentanaPrestamo();
            ventana.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VentanaCliente ventana = new VentanaCliente();
            ventana.Show();
        }

        private void MoraBotton_Click(object sender, RoutedEventArgs e)
        {
            VentanaMora ventanamora = new VentanaMora();
            ventanamora.Show();
        }
    }
}
