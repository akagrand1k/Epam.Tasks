using KamDMS.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamDMS.Entities.Models;
using KamDMS.DaoContracts;
using System.Data.Entity;

namespace KamDMS.ServiceContracts
{
    public class DepBranchService : IDepBranchService
    {
        private IDaoHandler<DepBranch> depbranchDao;
        public DepBranchService(IDaoHandler<DepBranch> _depbranchDao)
        {
            this.depbranchDao = _depbranchDao;
        }
        public IEnumerable<DepBranch> GetAll
        {
            get
            {
                return depbranchDao.Get.Include(x=>x.Department).Where(x=>x.IsDelete == false);
            }
        }

        public bool Delete(string Id)
        {
            if (Id != null)
            {
                var entity = depbranchDao.GetById(Id);
                entity.IsDelete = true;
                depbranchDao.Update(entity);
                return true;
            }
            return false;
        }

        public bool Edit(DepBranch entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.DateCreate = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                entity.Id = Guid.NewGuid().ToString();
                return depbranchDao.Add(entity);
            }
            else
            {
                var editEntity = depbranchDao.GetById(entity.Id);

                editEntity.Id = entity.Id;
                editEntity.BranchLeader = entity.BranchLeader;
                editEntity.DepId = entity.DepId;
                editEntity.NameBranch = entity.NameBranch;
                editEntity.IsActive = entity.IsActive;
                editEntity.IsDelete = entity.IsDelete;
                editEntity.DateUpdate = editEntity.DateUpdate;

                return depbranchDao.Update(editEntity);
            }
        }

        public DepBranch GetDepBranchById(string Id)
        {
            if (Id != null)
            {
                return depbranchDao.GetById(Id);
            }
            return new DepBranch { };
        }
    }
}
