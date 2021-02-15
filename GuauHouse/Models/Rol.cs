using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Models
{
    [Table("ROLES")]
    public class Rol
    {
        [Key]
        [Column("ID")]
        public int IdRol { get; set; }
        [Column("ROL")]
        public String Nombre { get; set; }
    }
}
