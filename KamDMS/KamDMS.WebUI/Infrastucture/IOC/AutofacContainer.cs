using Autofac;
using Autofac.Integration.Mvc;
using KamDMS.EFDomain;
using KamDMS.Entities.Models;
using KamDMS.Entities.Models.Doc;
using KamDMS.Service.Contracts;
using KamDMS.ServiceContracts;
using KamDMS.ServiceContracts.DocType;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KamDMS.WebUI.Infrastucture.IOC
{
        public class AutofacContainer
        {
            public static void GetContainer(HttpContextBase httpContext = null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                builder.RegisterType<AppContext>().InstancePerLifetimeScope();

                builder.RegisterType<DocumentTypeService>().As<IDocumentTypeService>();
                builder.RegisterType<UserService>().As<IUserService>();
                builder.RegisterType<DepartmentService>().As<IDepartmentService>();
                builder.RegisterType<DepBranchService>().As<IDepBranchService>();

                builder.RegisterType<Repository<DocumentType>>().As<IDaoHandler<DocumentType>>();
                builder.RegisterType<Repository<AppUser>>().As<IDaoHandler<AppUser>>();
                builder.RegisterType<Repository<Department>>().As<IDaoHandler<Department>>();
                builder.RegisterType<Repository<DepBranch>>().As<IDaoHandler<DepBranch>>();


                var container =  builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
}