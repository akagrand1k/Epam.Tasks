using Epam._2._3_User.UserStore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._3_User
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStore.ListInit();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Add user");
                Console.WriteLine("2 - Show all users");
                ConsoleKeyInfo signal = Console.ReadKey(intercept: true);
                switch (signal.Key)
                {
                    case ConsoleKey.D1:
                        AddUser();
                        break;

                    case ConsoleKey.D2:
                        ShowUsers();
                        break;

                    case ConsoleKey.D0:
                        return;

                    default:
                        break;
                }
            }
        }

        private static void ShowUsers()
        {
            foreach (var item in MemoryStore.UserList)
            {
                Console.WriteLine("FirstName = {0}; MiddleName = {1}, LastName = {2}, Age = {3}, DateBirthday = {4}\n",item.FirstName,item.MiddleName,item.LastName,item.Age,item.DateBirthday);
            }
            Console.ReadLine();
        }

        private static void AddUser()
        {
            Console.WriteLine("Input user data, DateBirthday Format - dd/MM/yyyy:");

            User entity = new User();

            entity.FirstName = Console.ReadLine();
            entity.MiddleName = Console.ReadLine();
            entity.LastName = Console.ReadLine();
            entity.Age = int.Parse(Console.ReadLine());
            entity.DateBirthday = Convert.ToDateTime(Console.ReadLine());

            MemoryStore.UserList.Add(entity);
            Console.WriteLine("Successfully!");
            Console.ReadLine();
        }
    }
}