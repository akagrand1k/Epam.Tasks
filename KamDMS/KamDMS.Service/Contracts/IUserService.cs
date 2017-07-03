using KamDMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Service.Contracts
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetAll { get; }
    }
}
