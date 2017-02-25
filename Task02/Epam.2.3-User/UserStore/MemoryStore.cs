using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._3_User.UserStore
{
    public static class MemoryStore
    {
        public static List<User> UserList = new List<User>();


        public static void ListInit()
        {
            UserList = new List<User>
            {
                new User {FirstName = "Петров",MiddleName= "Иван",LastName = "Алексеевич", Age = 25, DateBirthday = DateTime.Now },
                new User {FirstName = "Сидоров",MiddleName= "Иван",LastName = "Алексеевич", Age = 25, DateBirthday = DateTime.Now },
                new User {FirstName = "Крюков",MiddleName= "Иван",LastName = "Алексеевич", Age = 25, DateBirthday = DateTime.Now },
                new User {FirstName = "Алексеев",MiddleName= "Иван",LastName = "Алексеевич", Age = 25, DateBirthday = DateTime.Now }
            };
        }
    }
}
