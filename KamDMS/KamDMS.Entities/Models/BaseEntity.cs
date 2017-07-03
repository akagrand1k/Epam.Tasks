using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.Entities.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        public BaseEntity()
        {
            //DateCreate = DateTime.Now;
            //DateUpdate = DateTime.Now;
            //Id = Guid.NewGuid().ToString();
        }
    }
}