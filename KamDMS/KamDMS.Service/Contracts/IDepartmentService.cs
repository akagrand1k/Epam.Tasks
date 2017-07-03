using KamDMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Service.Contracts
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll { get; }
        Department GetDepartmentById(string Id);
        bool Delete(string Id);
        bool Edit(Department entity);
    }
}
