using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._3_User
{
    public class User
    {
        private int age;

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirthday { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age<0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                age = value;
            }
        }
    }
}
