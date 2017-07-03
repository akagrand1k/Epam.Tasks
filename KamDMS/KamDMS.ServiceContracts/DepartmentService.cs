using KamDMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamDMS.Entities.Models;
using KamDMS.DaoContracts;

namespace KamDMS.ServiceContracts
{
    public class DepartmentService : IDepartmentService
    {
        private IDaoHandler<Department> departmentDao;
        public DepartmentService(IDaoHandler<Department> _departmentDao)
        {
            this.departmentDao = _departmentDao;
        }

        public IEnumerable<Department> GetAll
        {
            get
            {
                return departmentDao.Get.Where(x=>x.IsDelete == false);
            }
        }

        public bool Delete(string Id)
        {
            if (Id != null)
            {
                var entity = departmentDao.GetById(Id);
                entity.IsDelete = true;
                departmentDao.Update(entity);
                return true;
            }
            return false;
        }

        public bool Edit(Department entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.DateCreate = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                entity.Id = Guid.NewGuid().ToString();
                return departmentDao.Add(entity);
            }
            else
            {
                var editEntity = departmentDao.GetById(entity.Id);

                editEntity.NameDep = entity.NameDep;
                editEntity.LeadersName = entity.LeadersName;
                editEntity.IsActive = entity.IsActive;
                editEntity.IsDelete = entity.IsDelete;
                editEntity.DateUpdate = editEntity.DateUpdate;

                return departmentDao.Update(editEntity);
            }
        }

        public Department GetDepartmentById(string Id)
        {
            if (Id != null)
            {
                return departmentDao.GetById(Id);
            }
            return new Department { };
        }
    }
}
