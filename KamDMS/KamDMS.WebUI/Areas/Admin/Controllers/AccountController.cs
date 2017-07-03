using KamDMS.EFDomain;
using KamDMS.Entities.Models;
using KamDMS.Service.Contracts;
using KamDMS.WebUI.App_Start;
using KamDMS.WebUI.Areas.Admin.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles =KamDMS.Extension.Constant.RoleConstant._Admin)]
    public class AccountController : Controller 
    {
        private IDepBranchService depBranchService;
        private AppContext context = new AppContext();

        public AccountController(IDepBranchService _depBranchService)
        {
            this.depBranchService = _depBranchService;
        }

        public ActionResult ListUser()
        {
                var result = from user in context.Users
                             from role in context.Roles
                             where role.Users.Any(r => r.UserId == user.Id)
                             where user.IsDelete == false
                             select new UserViewModel
                             {
                                 Id = user.Id,
                                 FirstName = user.UserName,
                                 MiddleName = user.MiddleName,
                                 LastName = user.LastName,
                                 DateCreate = user.DateCreate,
                                 LastDateAuth = user.LastDateAuth,
                                 IsDelete = "Активен",
                                 RoleName = role.Name,
                                 BranchName = user.DepBranch.NameBranch
                             };
                return View(result);
        }


        public ActionResult Register()
        {
            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
            return View(new UserViewModel
            {
                BranchList = depBranchService.GetAll.ToList(),
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    BranchId = model.BranchId
                };
                ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
                var result = await UserManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded == false)
                {
                    ModelState.AddModelError("", "Недопустимый пароль");
                    model.BranchList = depBranchService.GetAll.ToList();
                    return View(model);
                }
                else
                {
                    await this.UserManager.AddToRoleAsync(user.Id, model.RoleName);
                    return RedirectToAction("ListUser", "Account");
                }

            }
            return View(model);
        }

        public ActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResetPassViewModel model = new ResetPassViewModel() { Id = id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ResetPassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var removePassword = UserManager.RemovePassword(model.Id);
            if (removePassword.Succeeded)
            {
                //Removed Password Success
                var AddPassword = UserManager.AddPassword(model.Id, model.NewPassword);
                if (AddPassword.Succeeded)
                {
                    TempData["AlertMessage"] = "Пароль успешно изменен";
                    return RedirectToAction("ListUser", "Account");
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        public async Task<ActionResult> Edit(string Id)
        {
            var user = await UserManager.FindByIdAsync(Id);
            if (user != null)
            {
                var model = new UpdateUserViewModel
                {
                    FirstName = user.UserName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    BranchList = depBranchService.GetAll.ToList(),
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("ListUser");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UpdateUserViewModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.UserName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.DateUpdate = DateTime.Now;
                user.BranchId = model.BranchId;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUser", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Что то пошло не так!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(model);
        }

        public ActionResult Ban()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Ban(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                user.IsDelete = true;
                IdentityResult result = await UserManager.UpdateAsync(user);

                return RedirectToAction("ListUser", "Account");

            }
            else
            {
                return View("Error", new string[] { "Пользователь не найден" });
            }
        }

        public ActionResult LockedUser()
        {
            var result = from user in context.Users
                         where user.IsDelete == true
                         select new UserViewModel
                         {
                             Id = user.Id,
                             FirstName = user.UserName,
                             MiddleName = user.MiddleName,
                             LastName = user.LastName,
                             LastDateAuth = user.LastDateAuth,
                             IsDelete = "Заблокирован",
                         };
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Unlock(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                user.IsDelete = false;
                IdentityResult result = await UserManager.UpdateAsync(user);

                return RedirectToAction("LockedUser", "Account");

            }
            else
            {
                return View("Error", new string[] { "Пользователь не найден" });
            }
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
    }
}