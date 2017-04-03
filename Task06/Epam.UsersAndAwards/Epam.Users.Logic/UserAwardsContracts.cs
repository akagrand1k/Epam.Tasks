using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users.Entities;
using Epam.Users.DAOContracts;
using Epam.Users.FileDAL;

namespace Epam.Users.Logic
{
    public class UserAwardsContracts : IUserAwardsCrud
    {
        private IUserAwardsDao userawardsdao;
        public UserAwardsContracts()
        {
            userawardsdao = new UserAwardsDao();
        }
        public IEnumerable<UserAwards> GetAllUserAwards
        {
            get
            {
                return userawardsdao.GetAll;
            }
        }

        public void CreateUserAwards(UserAwards ua)
        {
            if (ua == null )
                throw new ArgumentNullException();

            userawardsdao.CreateAwards(ua);
        }
    }
}
