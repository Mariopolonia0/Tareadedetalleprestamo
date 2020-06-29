using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.DAL;
using RegistroPrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroPrestamo.BLL
{
    class MoraBLL
    {
        public static bool Guardar(Mora mora)
        {
            if (!Existe(mora.MoraId))//si no existe insertamos
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="tarea">La entidad que se desea guardar</param>
        private static bool Insertar(Mora mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Mora.Add(mora);
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

        private static bool Modificar(Mora mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //busca la entidad en la base de datos y la elimina
                contexto.Database.ExecuteSqlRaw($"Delete FROM TareasDetalle Where TareaId={mora.MoraId}");

                foreach (var item in mora.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(mora).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var tarea = MoraBLL.Buscar(id);

                if (tarea != null)
                {
                    contexto.Mora.Remove(tarea); //remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }

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

        public static Mora Buscar(int id)
        {
            Mora tarea = new Mora();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Mora.Include(x => x.Detalle)
                    .Where(x => x.MoraId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }

        public static List<Mora> GetList(Expression<Func<Mora, bool>> criterio)
        {
            List<Mora> Lista = new List<Mora>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Mora.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Mora.Any(e => e.MoraId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }



    }
}
