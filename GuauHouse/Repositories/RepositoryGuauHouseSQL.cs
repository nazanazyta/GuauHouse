using GuauHouse.Data;
using GuauHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Repositories
{
    public class RepositoryGuauHouseSQL: IRepositoryGuauHouse
    {
        GuauHouseContext context;

        public RepositoryGuauHouseSQL(GuauHouseContext context)
        {
            this.context = context;
        }

        #region USUARIOS
        public User ValidateUser(String username, String password)
        {
            return this.context.Usuarios
                .SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        public int GetMaxId(String tabla)
        {
            if (tabla == "Usuarios")
            {
                int id = (from datos in this.context.Usuarios
                          select datos.IdUsuario).Count();
                if (id == 0)
                {
                    return 1;
                }
                return (from datos in this.context.Usuarios
                        select datos.IdUsuario).Max() + 1;
            }else if (tabla == "Perros")
            {
                return 1;
            }
            else
            {
                return 1;
            }
        }

        public User InsertUser(User user)
        {
            user.IdUsuario = this.GetMaxId("Usuarios");
            user.Rol = 2;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
            return user;
        }

        public User GetUserByUserName(String username)
        {
            return this.context.Usuarios.SingleOrDefault(x => x.UserName == username);
        }
        #endregion
    }
}
