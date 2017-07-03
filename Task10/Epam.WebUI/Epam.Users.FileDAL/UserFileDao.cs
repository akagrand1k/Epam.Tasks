using Epam.Users.DAOContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users.Entities;

namespace Epam.Users.FileDAL
{
    public class UserFileDao : IUserDao
    {
        private FileHandler handler = new FileHandler();
        public IEnumerable<User> GetAllUser
        {
            get
            {
                return handler.ReadAllEntity();
            }
        }

        public bool CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            if (handler.CSVWriter(user))
                return true;

            return false;
        }

        public bool DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            handler.DeleteUserByName(user);
            return true;
        }
    }
}
