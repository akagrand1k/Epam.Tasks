using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.LogicContracts
{
    public interface IUserContracts
    {
        void CreateUser(User user);
        void DeleteUser(User user);
        IEnumerable<User> GetAll { get; }
    }
}
