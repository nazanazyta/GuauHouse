using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Models
{
    [Table("PERROS")]
    public class Perro
    {
        [Key]
        [Column("ID")]
        public int IdPerro { get; set; }
        [Column("IDUSU")]
        public int IdUsu { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("ESTATURA")]
        public String Estatura { get; set; }
        [Column("FECHA_ALTA")]
        [Timestamp]
        public DateTime FechaAlta { get; set; }
    }
}
