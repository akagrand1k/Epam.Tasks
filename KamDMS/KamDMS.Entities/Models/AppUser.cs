using KamDMS.Entities.Models.Doc;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime LastDateAuth { get; set; }

        public string BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual DepBranch DepBranch { get; set; }

        public virtual ICollection<Document> FK_Document { get; set; }

        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        public AppUser()
        {
            DateCreate = DateTime.Now;
            DateUpdate = DateTime.Now;
            LastDateAuth = DateTime.Now;
        }
    }
}
