using Epam.BackupSystem_Logic.Implementation;
using Epam.BackupSystem_Logic.Tools;
using Epam.BackupSystem_Logic.Tools.constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_UI
{
    class Program
    {
        private static FileHandler handler = new FileHandler();

        static void Main(string[] args)
        {
            InitDepencies();
            WelcomeMenu();
         }

        private static void InitDepencies()
        {
            handler.CheckExistFolder(Folders.Storage);
            handler.CheckExistFolder(Folders.Backup);
            handler.CheckExistFolder(Folders.Config);

            if (!File.Exists(Folders.LogFile))
                File.Create(Folders.LogFile);
        }

        private static void WelcomeMenu()
        {
            Console.WriteLine("Hello choose function:\n"
                + "Press 1 - Monitoring Mode\n"
                + "Press 2 - Restoring Mode\n"
                + "Press q(Q) - for exit application\n"
                );

            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nMonitoring Mode\n");
                    Listener.RunListen(Folders.Storage, "*.txt", Helpers.FilesChangeEvent);
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("\nRestoring Mode\n Write restore date. Date format = dd.MM.yyyy HH:m\n");
                    RollBack.RoolBackChange(Helpers.DateParse(Console.ReadLine()));
                    Console.WriteLine("\nRestored successfull");
                    Console.ReadKey();
                    break;

                case ConsoleKey.Q:
                    Console.WriteLine("\nApplication closed...");
                    Console.ReadKey();
                    return;
            }
        }
    }
}