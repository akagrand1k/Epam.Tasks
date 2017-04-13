using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.LogicContracts
{
    public interface IUserAwardsCrud
    {
        void CreateUserAwards(UserAwards ua);
        IEnumerable<UserAwards> GetAllUserAwards { get; }
    }
}
