using KamDMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Areas.Admin.Models.DepBranchs
{
    public class DepBranchViewModel
    {
        public string Id { get; set; }
        public List<KamDMS.Entities.Models.Department> ListDep { get; set; }
        public List<DepBranch> ListDepBranch { get; set; }
        [Required(ErrorMessage = "Введите наименование отдела")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "Введите ФИО начальника отдела")]
        public string BranchLeaderName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        [Required(ErrorMessage = "Выберите подразделение")]
        public string DepId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public DepBranch SaveEntityByViewModel(DepBranchViewModel entity)
        {
            return new DepBranch
            {
                Id = entity.Id,
                DepId = entity.DepId,
                NameBranch = entity.BranchName,
                BranchLeader = entity.BranchLeaderName,
                DateCreate = entity.DateCreate,
                DateUpdate = entity.DateUpdate,
                IsActive = entity.IsActive,
                IsDelete = entity.IsDelete,
            };
        }

        public DepBranchViewModel SaveViewModelByEntity(DepBranch model)
        {
            return new DepBranchViewModel
            {
                Id = model.Id,
                DepId = model.DepId,
                BranchName = model.NameBranch,
                BranchLeaderName = model.BranchLeader,
                DateCreate = model.DateCreate,
                DateUpdate = model.DateUpdate,
                IsActive = model.IsActive,
                IsDelete = model.IsDelete,
            };
        }

        //[DisplayName("Подразделение")]
        //public IEnumerable<SelectListItem> SelectDepList
        //{
        //    get
        //    {
        //        foreach (var dep in DepList)
        //        {
        //            yield return new SelectListItem
        //            {
        //                Value = dep.Id.ToString(),
        //                Text = dep.NameDep
        //            };
        //        }
        //    }
        //}
    }
}