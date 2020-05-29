using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RegistroPrestamo.Entidades
{
    class Prestamo
    {
        [Key]
        public int idPestamo { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public int idpersona { get; set; }
        public double concepto { get; set; }
        public double monto { get; set; }
        public double Balance { get; set; }
    }
}
