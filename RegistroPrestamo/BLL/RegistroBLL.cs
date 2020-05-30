using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RegistroPrestamo.Entidades;
using RegistroPrestamo.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RegistroPrestamo.BLL
{
    class RegistroBLL
    {
        public static bool Guardar(Prestamo prestamo)
        {
            if (!Existe(prestamo.idpersona))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        public static bool Insertar(Prestamo registro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(registro);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        
        public static Prestamo Guardar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamo registro;

            try
            {
                registro = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return registro;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encotrado = false;

            try
            {
                encotrado = contexto.Prestamos.Any(e => e.idpersona == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encotrado;
        }

        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> cristerio)
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Prestamos.Where(cristerio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static Prestamo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamo registro;
            registro = contexto.Prestamos.Find(id);
            return registro;
        }
    }
}
