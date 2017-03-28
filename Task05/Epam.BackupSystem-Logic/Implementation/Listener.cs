using Epam.BackupSystem_Logic.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Implementation
{
    public class Listener
    {
        private Listener() {}

        private static FileHandler handler = new FileHandler();
        private static Logger logger = new Logger();

        public static FileSystemWatcher watcher = new FileSystemWatcher();

        /// <summary>
        /// Monitoring folder schedule.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="extenstionFilter"></param>
        /// <param name="changeEvent"></param>
        /// 
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void RunListen(string folder, string extensionFilter, Action<object, FileSystemEventArgs> sender)
        {
            if (sender != null)
            {
                FileSystemWatcher watcher = new FileSystemWatcher(folder, extensionFilter);

                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;


                watcher.Created += new FileSystemEventHandler(sender);
                watcher.Changed += new FileSystemEventHandler(sender);

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Enter \'q\' for close application");
                while (Console.Read() != 'q') ;
            }
            else
                throw new ArgumentNullException();
            }
        }
    }
}
