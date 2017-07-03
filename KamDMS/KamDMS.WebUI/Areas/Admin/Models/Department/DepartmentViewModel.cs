using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KamDMS.WebUI.Areas.Admin.Models.Department
{
    public class DepartmentViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Введите наименование подразделения!")]
        public string DepName { get; set; }
        [Required(ErrorMessage = "Укажите руководителя!")]
        public string LeadersName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }

        public List<KamDMS.Entities.Models.Department> ListDepartment { get; set; }

        public DepartmentViewModel SaveEntityToViewModel(KamDMS.Entities.Models.Department entity)
        {
            return new DepartmentViewModel
            {
                Id = entity.Id,
                DateCreate = entity.DateCreate,
                DateUpdate = entity.DateUpdate,
                DepName = entity.NameDep,
                LeadersName = entity.LeadersName,
            };
        }

        public KamDMS.Entities.Models.Department SaveViewModelByEntity(DepartmentViewModel model)
        {
            return new Entities.Models.Department
            {
                Id = model.Id,
                DateCreate = model.DateCreate,
                DateUpdate = model.DateUpdate,
                NameDep = model.DepName,
                LeadersName = model.LeadersName,
            };
        }
    }
}