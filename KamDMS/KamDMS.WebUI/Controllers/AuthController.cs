using KamDMS.Entities.Models;
using KamDMS.WebUI.App_Start;
using KamDMS.WebUI.Models.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Controllers
{
    public class AuthController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Доступ запрещен" });
            }

            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AuthViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(model.UserName, model.Password);

                if (user == null)
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                else
                {
                    if (user.IsDelete == false)
                    {
                        ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                        user.LastDateAuth = DateTime.Now;
                        await UserManager.UpdateAsync(user);
                        AuthManager.SignOut();

                        AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                        ModelState.AddModelError("", "Аккаунт заблокирован");
                }
                ViewBag.returnUrl = returnUrl;
            }

            return View(model);
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

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Login", "Auth");
        }
    }
}