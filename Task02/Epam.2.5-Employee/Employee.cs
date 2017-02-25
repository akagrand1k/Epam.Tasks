using Epam._2._3_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._5_Employee
{
    public class Employee : User
    {
        private int salary;
        private int workExp;
        private string post;

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (salary <=0)
                {
                    throw new ArgumentException("Salary");
                }
                salary = value;
            }
        }

        public int Experience
        {
            get
            {
                return workExp;
            }
            set
            {
                if (workExp <0)
                {
                    throw new ArgumentException("Experience");
                }
                workExp = value;
            }
        }

        public string Post
        {
            get
            {
                return post;
            }

            set
            {
                if (string.IsNullOrEmpty(post))
                {
                    throw new NullReferenceException("Post");
                }
                post = value;
            }
        }
    }
}
