using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.DAOContracts
{
    public interface IAwardsDao
    {
        bool CreateAwards(Award award);
        IEnumerable<Award> GetAwards { get; }
        string GetAwardsById(int id);
    }
}
