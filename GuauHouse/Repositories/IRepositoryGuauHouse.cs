using GuauHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //User EditUser(User user, String passant, String passnue1);

        #endregion

        #region PERROS

        List<Perro> GetPerrosIdUser(int idusu);
        Perro GetPerroId(int idperro);
        Perro InsertarPerro(Perro perro);
        Perro EditarPerro(Perro perro);
        void BorrarPerro(int idperro);

        #endregion

        #region RESERVAS

        void InsertarReserva(Reserva reserva);
        #endregion
    }
}
