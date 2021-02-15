using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Helpers
{
    public class Enumerations
    {
        public enum Roles
        {
            Admin = 1, Usuario = 2, Empleado = 3
        }

        public enum Estaturas
        {
            Grande, Mediano, Pequeño
        }

        public enum Turnos
        {
            Mañana, Tarde
        }

        public enum Folders
        {
            Images = 0, Documents = 1, Temporal = 2
        }
    }
}
