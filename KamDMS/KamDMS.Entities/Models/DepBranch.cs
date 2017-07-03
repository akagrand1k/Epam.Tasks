using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Entities.Models
{
    public class DepBranch : BaseEntity
    {
        public string NameBranch { get; set; }
        public string BranchLeader { get; set; }
        public string DepId { get; set; }

        [ForeignKey("DepId")]
        public virtual Department Department { get; set; }

        public virtual ICollection<AppUser> BranchUsers { get; set; }
    }
}
