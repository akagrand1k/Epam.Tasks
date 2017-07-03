using KamDMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Service.Contracts
{
    public interface IDepBranchService
    {
        IEnumerable<DepBranch> GetAll { get; }
        DepBranch GetDepBranchById(string Id);
        bool Delete(string Id);
        bool Edit(DepBranch entity);
    }
}
