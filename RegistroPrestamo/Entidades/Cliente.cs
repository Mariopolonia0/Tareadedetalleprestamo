using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPrestamo.Entidades
{
    class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }
        public string direcion { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
    }
}
