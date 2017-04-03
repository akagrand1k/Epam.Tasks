using Epam.Users.Constants;
using Epam.Users.Entities;
using Epam.Users.Extension;
using Epam.Users.FileDAL;
using Epam.Users.Logic;
using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.UI
{
    public class StartApplication
    {
        private static IUserContracts userlogic;
        private static IAwardsCrud awardslogic;
        private static IUserAwardsCrud userawardslogic;

        public StartApplication()
        {
            userlogic = new UserContracts();
            awardslogic = new AwardsContracts();
            userawardslogic = new UserAwardsContracts();
            ExtensionInit();
        }

        private static FileHandler handler = new FileHandler();
        public void ExtensionInit()
        {
            AppExtension.CheckSystemFolder();
            AppExtension.CheckSystemFile();
            handler.WriteHeader(AppExtension.GetUserHeader, AppConst.dataPath);
            handler.WriteHeader(AppExtension.GetAwardsProperty, AppConst.awardsPath);
            handler.WriteHeader(AppExtension.GetUserAwardsProperty, AppConst.userAwardsPath);
        }

        public static void StartMenu()
        {
            Console.WriteLine("Hello User!   "
                + "You would enter next commands:\n"
                + "1 - Show all users\n"
                + "2 - Create new users\n"
                + "3 - Delete users by Name\n"
                + "4 - Create awards\n"
                + "5 - Show awards list\n"
                + "6 - Add awards for user\n"
                + "q - For exit application\n"
                );
            CaseMenu();
        }

        private static void CaseMenu()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    ShowUserList();
                    break;

                case ConsoleKey.D2:
                    CreateUser();
                    break;

                case ConsoleKey.D3:
                    DeleteUser();
                    break;

                case ConsoleKey.D4:
                    AwardsCreate();
                    break;

                case ConsoleKey.D5:
                    ShowAwards();
                    break;

                case ConsoleKey.D6:
                    AddUserAwards();
                    break;

                case ConsoleKey.Q:
                    Console.WriteLine("\nApplication closed...");
                    Console.ReadKey();
                    return;

            }
        }

        private static void AddUserAwards()
        {
            var users = userlogic.GetAll;
            var awards = awardslogic.GetAll;
            UserAwards ua = new UserAwards();

            Console.WriteLine("\nUsers\n\n\n");
            PrintUsers(users);
            Console.WriteLine("Awards\n\n\n");
            PrintAwards(awards);
            Console.WriteLine("Write Username for gived awards");
            var name = Console.ReadLine();
            ua.UserId = users.Where(x => x.Name.Contains(name)).FirstOrDefault().Id;
            Console.WriteLine("Write awards title");
            var title = Console.ReadLine();
            ua.AwardsId = awards.Where(x => x.Title.Contains(title)).FirstOrDefault().Id;
            userawardslogic.CreateUserAwards(ua);
            Console.WriteLine("User awards add Successfull");
            Console.Clear();
            AddUserAwards();
        }

        private static void ShowAwards()
        {
            Console.Clear();
            var entities = awardslogic.GetAll;
            if (entities == null)
            {
                Console.WriteLine("Awards not found. Please create awards");
                returnToMenu();
            }
            else
            {
                Console.WriteLine($"Total awards:{entities.Count()}");
                PrintAwards(entities);
                returnToMenu();
            }
        }

        private static void PrintAwards(IEnumerable<Award> entities)
        {
            foreach (var item in entities)
            {
                Console.WriteLine($"Id = {item.Id};  Title = {item.Title}");
            }
        }
        private static void AwardsCreate()
        {
            Console.Clear();
            Award award = new Award();
            Console.WriteLine("Enter Award title:\n");
            Console.WriteLine("Title:");
            award.Title = Console.ReadLine();
            awardslogic.AddAwards(award);
            Console.WriteLine("Awards create successfull");
            returnToMenu();
        }

        private static void returnToMenu()
        {
            Console.ReadLine();
            Console.Clear();
            StartMenu();
        }

        #region User

        private static void DeleteUser()
        {
            var entities = userlogic.GetAll;
            PrintUsers(entities);
            Console.WriteLine("Enter the name user for delete:");
            var user = new User();
            user.Name = Console.ReadLine();
            userlogic.DeleteUser(user);
            PrintUsers(entities = userlogic.GetAll);
            returnToMenu();
        }

        private static void CreateUser()
        {
            Console.Clear();
            User user = new User();
            Console.WriteLine("Enter user data:\n");
            Console.WriteLine("Name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Date of Birthday, Date Format: 10.10.2016:");
            user.DateOfBirth = AppExtension.DateFormat(Console.ReadLine());
            Console.WriteLine("Age:");
            user.Age = int.Parse(Console.ReadLine());
            userlogic.CreateUser(user);
            Console.WriteLine("User create successfull");
            returnToMenu();
        }

        private static void ShowUserList()
        {
            Console.Clear();
            var entities = userlogic.GetAll;
            if (entities == null)
            {
                Console.WriteLine("Users not found. Please create user");
                returnToMenu();
            }
            else
            {
                Console.WriteLine($"Total users:{entities.Count()}");
                PrintUsers();
                returnToMenu();
            }
        }

        private static void PrintUsers(IEnumerable<User> entities)
        {
            foreach (var item in entities)
            {
                Console.WriteLine($"Id = {item.Id};  Name = {item.Name};  DateBirthday = {item.DateOfBirth.ToShortDateString()};  Age = {item.Age}");
            }
        }

        private static void PrintUsers()
        {
            var userawards = userawardslogic.GetAllUserAwards;
            var awards = awardslogic.GetAll;
            var users = userlogic.GetAll;

            foreach (var user in users)
            {
                var temp = StringConcat(user);
                foreach (var ua in userawards)
                {
                    if (user.Id == ua.UserId)
                        temp += "\nMedals:" + awardslogic.GetById(ua.AwardsId) +";";
                }
                Console.WriteLine(temp);
            }
        }

        public string GetAwardsById(int id)
        {
            return awardslogic.GetAll.Where(x => x.Id.ToString().Contains(id.ToString())).FirstOrDefault().Title;
        }

        private string AwardsList(int userid)
        {
            return string.Empty;
        }
        private static string StringConcat(User item)
        {
            return $"Id = {item.Id};  Name = {item.Name};  DateBirthday = {item.DateOfBirth.ToShortDateString()};  Age = {item.Age}";
        }
        #endregion
    }
}