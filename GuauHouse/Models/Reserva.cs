using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Models
{
    [Table("RESERVAS")]
    public class Reserva
    {
        [Key]
        [Column("ID")]
        public int IdReserva { get; set; }
        [Column("IDUSU")]
        public int IdUsu { get; set; }
        [Column("IDPER")]
        public int IdPer { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("TURNO")]
        public String Turno { get; set; }
        [Column("FECHA_ALTA")]
        [Timestamp]
        public DateTime FechaAlta { get; set; }
    }
}
