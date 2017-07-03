using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.DAOContracts
{
    public interface IFileDao
    {
        bool CSVWriter(User user);
        bool CSVWriter(Award award);
        bool CSVWriter(UserAwards aw);
        void WriteHeader(IEnumerable<string> header, string file);
        IEnumerable<User> ReadAllEntity();
        IEnumerable<Award> ReadAllAwards();
        IEnumerable<UserAwards> ReadAllUserAwards();
        bool DeleteUserByName(User user);
    }
}
