using Epam.BackupSystem_Logic.Contract;
using System;
using System.IO;
using System.Security.Permissions;

namespace Epam.BackupSystem_Logic.Implementation
{
    public class FolderListener : IListener
    {
        /// <summary>
        /// Monitoring folder schedule.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="extenstionFilter"></param>
        /// <param name="changeEvent"></param>
        /// 
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void RunListen(string folder,string extensionFilter,Action<object,FileSystemEventArgs> sender)
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
    }
}
