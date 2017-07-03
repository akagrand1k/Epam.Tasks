using Epam.Users.DAOContracts;
using Epam.Users.Entities;
using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Logic
{
    public class UserContracts : IUserContracts
    {
        private IUserDao userdao;
        public UserContracts()
        {
            userdao = DaoProvider.UserDao;
        }

        public IEnumerable<User> GetAll
        {
            get
            {
                return userdao.GetAllUser;
            }
        }

        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            userdao.CreateUser(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            userdao.DeleteUser(user);
        }
    }
}
