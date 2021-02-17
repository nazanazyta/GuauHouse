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
    public interface IRepositoryGuauHouse
    {
        int GetMaxId(String tabla);

        #region USUARIOS

        User ValidateUser(String username, String password);
        User InsertUser(User user);
        User GetUserByUserName(String username);
        User GetUserById(int idusuario);
        User EditUser(User user);
        void InsertarEmpleado(User user);
        List<User> GetEmpleados();
        void EliminarEmpleado(int idusuario);
        //User EditUser(User user, String passant, String passnue1);

        #endregion

        #region PERROS

        List<Perro> GetPerrosByIdUser(int idusu);
        Perro GetPerroId(int idperro);
        Perro InsertarPerro(Perro perro);
        Perro EditarPerro(Perro perro);
        void BorrarPerro(int idperro);

        #endregion

        #region RESERVAS

        void InsertarReserva(Reserva reserva);
        List<ReservaUsuario> GetReservasUsuarioByIdUsuario(int idusu);
        ReservaUsuario GetReservaUsuarioById(int idreserva);
        Reserva GetReservaById(int idreserva);
        void EditarReserva(Reserva reserva);
        void EliminarReserva(int idreserva);
        List<ReservaUsuario> GetReservasUsuarioByDay();

        #endregion
    }
}
