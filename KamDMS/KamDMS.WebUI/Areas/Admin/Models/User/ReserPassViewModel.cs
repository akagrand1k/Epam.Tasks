using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KamDMS.WebUI.Areas.Admin.Models.User
{
    public class ResetPassViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Минимальная длина пароля 6 символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}