using Epam.Users.DAOContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users.Entities;

namespace Epam.Users.FileDAL
{
    public class UserAwardsDao : IUserAwardsDao
    {
        private FileHandler handler = new FileHandler();

        public IEnumerable<UserAwards> GetAll
        {
            get
            {
                return handler.ReadAllUserAwards();
            }
        }

        public bool CreateAwards(UserAwards ua)
        {
            if (ua == null)
                throw new ArgumentNullException();

            handler.CSVWriter(ua);
            return true;
        }
    }
}
