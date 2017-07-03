using KamDMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Areas.Admin.Models.User
{
    public class UpdateUserViewModel
    {
        public List<DepBranch> BranchList { get; set; }

        public string Id { get; set; }

        [Required(ErrorMessage = "Введите фамилию!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите имя!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Введите отчество")]
        public string LastName { get; set; }

        public string BranchId { get; set; }

        public IEnumerable<SelectListItem> SelectBranchList
        {
            get
            {
                foreach (var branch in BranchList)
                {
                    yield return new SelectListItem
                    {
                        Value = branch.Id,
                        Text = branch.NameBranch
                    };
                }
            }
        }
    }
}