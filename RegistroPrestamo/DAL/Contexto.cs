using Microsoft.EntityFrameworkCore;
using RegistroPrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamo.DAL
{
    class Contexto : DbContext
    {
       public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\PrestamoControl.db");
        }
    }
}
