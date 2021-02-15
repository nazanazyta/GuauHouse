using GuauHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Repositories
{
    public interface IRepositoryGuauHouse
    {
        User ValidateUser(String username, String password);
        int GetMaxId(String tabla);
        User InsertUser(User user);
        User GetUserByUserName(String username);
        List<Perro> GetPerrosUserName(String username);
        User EditUser(User user);
    }
}
