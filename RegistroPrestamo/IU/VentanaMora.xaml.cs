using RegistroPrestamo.BLL;
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

namespace RegistroPrestamo.IU
{
    /// <summary>
    /// Interaction logic for Mora.xaml
    /// </summary>
    public partial class VentanaMora : Window
    {

        private Mora mora = new Mora();
        
        public VentanaMora()
        {
            InitializeComponent();
            this.DataContext = mora;  
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = mora;
        }

        private void Limpiar()
        {
            this.mora = new Mora();
            this.DataContext = mora;
        }

        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            Mora encontrado = MoraBLL.Buscar(mora.MoraId);

            if (encontrado != null)
            {
                mora = encontrado;
                Cargar();
                MessageBox.Show("Tarea encontrada", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Tarea no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void AgregarBotton_Click(object sender, RoutedEventArgs e)
        {
            mora.Detalle.Add(new MoraDetalle(mora.MoraId,Convert.ToInt32(PrestamoIdTextBox.Text),Convert.ToInt32(ValorTextBox.Text) ));
            Cargar();

            PrestamoIdTextBox.Clear();
            ValorTextBox.Clear();

        }

        private void QuitarBotton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count > 1 && DetalleDataGrid.SelectedIndex < DetalleDataGrid.Items.Count - 1)
            { 
                mora.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
    }
}
