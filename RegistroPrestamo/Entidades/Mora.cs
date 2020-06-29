using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroPrestamo.Entidades
{
    public class Mora
    {
        [Key]

        public int MoraId { get; set; }
        public DateTime fecha { get; set; }

        public double Total { get; set; }

        [ForeignKey("MoraId")]
        public List<MoraDetalle> Detalle { get; set; } = new List<MoraDetalle>();

    }

    public class MoraDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public double Valor { get; set; }

        public MoraDetalle(int moraId, int prestamoId,double valor)
        {
            Id = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;

        }
    }
}
