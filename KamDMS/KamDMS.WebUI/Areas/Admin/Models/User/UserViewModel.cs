using KamDMS.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Areas.Admin.Models.User
{
    public class UserViewModel
    {
        public List<DepBranch> BranchList { get; set; }
        public string Id { get; set; }
        public string BranchId { get; set; }

        [Required(ErrorMessage = "Введите Фамилию!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите Имя!")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Введите Отчество!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; }
        public string BranchName { get; set; }
        public string IsDelete { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime LastDateAuth { get; set; }

        [Display(Name = "Выберите отдел:")]
        public IEnumerable<SelectListItem> SelectBranchList
        {
            get
            {
                foreach (var branch in BranchList)
                {
                    yield return new SelectListItem
                    {
                        Value = branch.Id.ToString(),
                        Text = branch.NameBranch
                    };
                }
            }
        }
    }
}