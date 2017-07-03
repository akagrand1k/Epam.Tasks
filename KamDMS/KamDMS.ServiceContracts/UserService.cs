using KamDMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamDMS.Entities.Models;
using KamDMS.DaoContracts;
using System.Data.Entity;
using KamDMS.EFDomain;

namespace KamDMS.ServiceContracts
{
    public class UserService : IUserService
    {
        private IDaoHandler<AppUser> userDao;

        public UserService(IDaoHandler<AppUser> _userDao)
        {
            this.userDao = _userDao;
        }

        public IEnumerable<AppUser> GetAll
        {
            get
            {
                using (var ctx = new AppContext())
                {
                    var result = ctx.Users.Include(x => x.Roles);
                    return result;
                }
            }   
        }
    }
}
