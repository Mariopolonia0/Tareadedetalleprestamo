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
        }

        private void RegistroPrestamo_Click(object sender, RoutedEventArgs e)
        {
            UsuarioTextBox.Text = "Mario";
            ContrasenaTextBox.Text = "******";
            VentanaPrestamo ventana = new VentanaPrestamo();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsuarioTextBox.Text = "Mario";
            ContrasenaTextBox.Text = "******";
            VentanaCliente ventana = new VentanaCliente();
            ventana.Owner = this;
            ventana.ShowDialog();
        }
    }
}
