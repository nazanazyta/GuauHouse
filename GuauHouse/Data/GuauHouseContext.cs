using GuauHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Data
{
    public class GuauHouseContext: DbContext
    {
        public GuauHouseContext(DbContextOptions<GuauHouseContext> options)
            : base(options) { }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Perro> Perros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<ReservaUsuario> ReservasUsuario { get; set; }
    }
}
