namespace KamDMS.EFDomain.Migrations
{
    using Entities.Models;
    using Extension.Constant;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KamDMS.EFDomain.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KamDMS.EFDomain.AppContext context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            var rAdmin = new AppRole { Name = RoleConstant._Admin };
            var rModer = new AppRole { Name = RoleConstant._Moderator };
            var rSuperUser = new AppRole { Name = RoleConstant.SuperUser };
            var rUser = new AppRole { Name = RoleConstant._User };

            roleManager.Create(rAdmin);
            roleManager.Create(rModer);
            roleManager.Create(rSuperUser);
            roleManager.Create(rUser);
            var AdminUser = new AppUser
            {
                UserName = "Leontev",
                MiddleName = "Maksim",
                LastName = "Stanislavovich",
            };

            string pass = "9DBy78BUm5";
            var result = userManager.Create(AdminUser, pass);

            if (result.Succeeded)
            {
                userManager.AddToRole(AdminUser.Id, rAdmin.Name);
            }
        }
    }
}