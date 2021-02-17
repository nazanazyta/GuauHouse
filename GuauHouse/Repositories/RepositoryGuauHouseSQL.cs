using GuauHouse.Data;
using GuauHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#region VISTAS

//CREATE VIEW reservasdeusuario
//AS
//	SELECT R.ID, R.IDUSU, R.IDPER, P.NOMBRE AS NOMBREPERRO, R.FECHA, R.TURNO, R.FECHA_ALTA
//	FROM PERROS P INNER JOIN RESERVAS R ON (P.ID = R.IDPER)
//GO

#endregion

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
                int id = (from datos in this.context.Reservas
                          select datos.IdReserva).Count();
                if (id == 0)
                {
                    return 1;
                }
                return (from datos in this.context.Reservas
                        select datos.IdReserva).Max() + 1;
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

        public void InsertarEmpleado(User user)
        {
            user.IdUsuario = this.GetMaxId("Usuarios");
            user.Rol = 3;
            user.FechaAlta = DateTime.Now;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public List<User> GetEmpleados()
        {
            return this.context.Usuarios.Where(x => x.Rol == 3).ToList();
        }

        public void EliminarEmpleado(int idusuario)
        {
            User usuario = this.GetUserById(idusuario);
            this.context.Usuarios.Remove(usuario);
            this.context.SaveChanges();
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
        public List<Perro> GetPerrosByIdUser(int idusu)
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

        public List<ReservaUsuario> GetReservasUsuarioByIdUsuario(int idusu)
        {
            return this.context.ReservasUsuario.Where(x => x.IdUsu == idusu).ToList();
        }

        public ReservaUsuario GetReservaUsuarioById(int idreserva)
        {
            return this.context.ReservasUsuario.SingleOrDefault(x => x.IdReserva == idreserva);
        }

        public Reserva GetReservaById(int idreserva)
        {
            return this.context.Reservas.SingleOrDefault(x => x.IdReserva == idreserva);
        }

        public void EditarReserva(Reserva reserva)
        {
            Reserva res = this.GetReservaById(reserva.IdReserva);
            res.IdPer = reserva.IdPer;
            if (reserva.Fecha >= DateTime.Now)
            {
                res.Fecha = reserva.Fecha;
            }
            res.Turno = reserva.Turno;
            res.FechaAlta = DateTime.Now;
            this.context.SaveChanges();
        }

        public void EliminarReserva(int idreserva)
        {
            Reserva reserva = this.GetReservaById(idreserva);
            this.context.Reservas.Remove(reserva);
            this.context.SaveChanges();
        }

        public List<ReservaUsuario> GetReservasUsuarioByDay()
        {
            return this.context.ReservasUsuario.Where(x => x.Fecha.Day == DateTime.Now.Day).OrderBy(z => z.Turno).ToList();
        }
        #endregion
    }
}
