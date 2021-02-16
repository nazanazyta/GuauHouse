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
            }
            else if (tabla == "Perros")
            {
                int id = (from datos in this.context.Perros
                          select datos.IdPerro).Count();
                if (id == 0)
                {
                    return 1;
                }
                return (from datos in this.context.Perros
                        select datos.IdPerro).Max() + 1;
            }
            else
            {
                return 1;
            }
        }

        #region USUARIOS
        public User ValidateUser(String username, String password)
        {
            return this.context.Usuarios
                .SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        public User InsertUser(User user)
        {
            user.IdUsuario = this.GetMaxId("Usuarios");
            user.Rol = 2;
            user.FechaAlta = DateTime.Now;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
            return user;
        }

        public User GetUserByUserName(String username)
        {
            return this.context.Usuarios.SingleOrDefault(x => x.UserName == username);
        }

        public User GetUserById(int idusuario)
        {
            return this.context.Usuarios.Where(x => x.IdUsuario == idusuario).FirstOrDefault();
        }

        public User EditUser(User user)
        {
            User usuario = this.GetUserById(user.IdUsuario);
            usuario.Nombre = user.Nombre;
            usuario.Apellidos = user.Apellidos;
            usuario.Dni = user.Dni;
            usuario.Email = user.Email;
            usuario.Telefono = user.Telefono;
            usuario.Imagen = user.Imagen;
            this.context.SaveChanges();
            return usuario;
        }

        //public User EditUser(User user, String passant, String passnue1)
        //{
        //    User usuario = this.GetUserById(user.IdUsuario);
        //    if (usuario.Password != passant)
        //    {
        //        usuario.Nombre = user.Nombre;
        //        usuario.Apellidos = user.Apellidos;
        //        usuario.Dni = user.Dni;
        //        usuario.Email = user.Email;
        //        usuario.Telefono = user.Telefono;
        //        usuario.Imagen = user.Imagen;
        //        usuario.UserName = user.UserName;
        //        this.context.SaveChanges();
        //        return null;
        //    }
        //    else
        //    {
        //        usuario.Nombre = user.Nombre;
        //        usuario.Apellidos = user.Apellidos;
        //        usuario.Dni = user.Dni;
        //        usuario.Email = user.Email;
        //        usuario.Telefono = user.Telefono;
        //        usuario.Imagen = user.Imagen;
        //        usuario.UserName = user.UserName;
        //        this.context.SaveChanges();
        //        return usuario;
        //    }
        //}
        #endregion

        #region PERROS
        public List<Perro> GetPerrosIdUser(int idusu)
        {
            //this.context.Usuarios.Where(x => x.UserName == username).Select(z => z.IdUsuario);
            //return this.context.Perros.Where(x => x.IdUsu == iduser).Select(z => z.Nombre).ToList();
            //int id = this.context.Usuarios.SingleOrDefault(x => x.UserName == username).IdUsuario;
            return this.context.Perros.Where(z => z.IdUsu == idusu).ToList();
            //return this.context.Perros.Where(x => x.IdUsu == 
            //    (this.context.Usuarios.Where(z => z.UserName == username).Select(y => y.IdUsuario)));
            //return (from datos in this.context.Perros
            //        where datos.IdUsu == iduser
            //        select datos.Nombre).ToList();
        }

        public List<Perro> GetPerrosIdUsuario(int idusuario)
        {
            return this.context.Perros.Where(z => z.IdUsu == idusuario).ToList();
        }

        public Perro GetPerroId(int idperro)
        {
            return this.context.Perros.Where(x => x.IdPerro == idperro).FirstOrDefault();
        }

        public Perro InsertarPerro(Perro perro)
        {
            perro.IdPerro = this.GetMaxId("Perros");
            perro.FechaAlta = DateTime.Now;
            Perro p = this.context.Perros.Add(perro).Entity;
            this.context.SaveChanges();
            return p;
        }

        public Perro EditarPerro(Perro perro)
        {
            Perro p = this.GetPerroId(perro.IdPerro);
            p.Nombre = perro.Nombre;
            p.Estatura = perro.Estatura;
            p.Foto = perro.Foto;
            this.context.SaveChanges();
            return p;
        }

        public void BorrarPerro(int idperro)
        {
            Perro perro = this.context.Perros.SingleOrDefault(x => x.IdPerro == idperro);
            this.context.Remove(perro);
            this.context.SaveChanges();
        }
        #endregion

        #region RESERVAS
        public void InsertarReserva(Reserva reserva)
        {
            reserva.IdReserva = this.GetMaxId("Reservas");
            reserva.FechaAlta = DateTime.Now;
            this.context.Reservas.Add(reserva);
            this.context.SaveChanges();
        }
        #endregion
    }
}
