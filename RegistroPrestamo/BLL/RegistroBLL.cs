using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RegistroPrestamo.Entidades;
using RegistroPrestamo.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Windows;
using RegistroPrestamo;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RegistroPrestamo.BLL
{
    class RegistroBLL 
    {
        
        public static double Guardar(Prestamo prestamo)
        {
            Contexto contexto = new Contexto();
            prestamo.concepto = -1 * prestamo.concepto;
            double dividiendo = (0.01 * prestamo.monto);
            double divisor = Math.Pow((1 + 0.01), prestamo.concepto);
            divisor = divisor - 1;
            divisor = Math.Round(divisor, 2);
            divisor = -1 * divisor;
            divisor = dividiendo / divisor;
            divisor = Math.Round(divisor, 2);
            prestamo.Balance = divisor;
            contexto.Prestamos.Add(prestamo);
            contexto.SaveChanges();
            return divisor;
        }

        public static void GuardarCliente(Cliente cliente)
        {
            Contexto contexto = new Contexto();
    
            
            try
            {
                contexto.Clientes.Add(cliente);
                contexto.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
        }


    }
}
