using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.DAOContracts
{
    public interface IUserDao
    {
        bool CreateUser(User user);
        bool DeleteUser(User user);
        IEnumerable<User> GetAllUser { get; }
    }
}