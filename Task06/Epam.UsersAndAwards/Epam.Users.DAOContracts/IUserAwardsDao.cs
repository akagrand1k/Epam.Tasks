using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.DAOContracts
{
    public interface IUserAwardsDao
    {
        bool CreateAwards(UserAwards ua);
        IEnumerable<UserAwards> GetAll { get;}
    }
}
