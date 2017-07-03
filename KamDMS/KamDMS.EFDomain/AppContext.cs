using KamDMS.Entities.Models;
using KamDMS.Entities.Models.Doc;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.EFDomain
{
    public class AppContext : IdentityDbContext<AppUser>
    {
        public AppContext() : base("KamDMS")
        {
            Database.SetInitializer<AppContext>(new MigrateDatabaseToLatestVersion<AppContext, KamDMS.EFDomain.Migrations.Configuration>());
        }

        public static AppContext Create()
        {
            return new AppContext();
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<DepBranch> DepBranch { get; set; }
        public DbSet<SignedLeader> SignedLeader { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentType> TypeDocument { get; set; }
        public DbSet<ArgumentList> ArgumentList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DocumentType>() //disable cascade delete
                .HasMany(x => x.FK_Document)
                .WithRequired()
                .HasForeignKey(c => c.TypeId)
                .WillCascadeOnDelete(false);
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(AppContext context)
        {

        }
    }
}
