using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Entities.Models
{
    public class Department : BaseEntity
    {
        public string NameDep { get; set; }
        public string LeadersName { get; set; }

        public virtual ICollection<DepBranch> FK_DepBranch { get; set; }
    }
}
