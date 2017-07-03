using Epam.Users.DAOContracts;
using Epam.Users.FileDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Logic
{
    internal static class DaoProvider
    {
        static DaoProvider()
        {
            UserDao = new UserFileDao();
            AwardsDao = new AwardsDao();
            userAwardsDao = new UserAwardsDao();
        }
        public static IUserDao UserDao { get; }
        public static IAwardsDao AwardsDao { get; }
        public static IUserAwardsDao userAwardsDao { get; }
        public static IFileDao fileDao { get; }
    }
}
