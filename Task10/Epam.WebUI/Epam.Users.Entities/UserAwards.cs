using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Entities
{
    public class UserAwards
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AwardsId { get; set; }
    }
}
