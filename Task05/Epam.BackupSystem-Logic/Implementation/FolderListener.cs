using Epam.BackupSystem_Logic.Contract;
using Epam.BackupSystem_Logic.Tools;
using Epam.BackupSystem_Logic.Tools.constants;
using System;
using System.IO;
using System.Security.Permissions;

namespace Epam.BackupSystem_Logic.Implementation
{
    public class FolderListener : IListener
    {
        private FileHandler handler = new FileHandler();
        private Logger logger = new Logger();
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
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Rollback files by date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool RoolBackChange(DateTime date)
        {
            var filterFiles = handler.GetFilesByDate(date);
            FileInfo info = null;
            foreach (var item in filterFiles)
            {
                info = new FileInfo(item);
                handler.FileStorageCopy(item, Folders.Storage + @"\" + info.Name);
            }
            logger.SendLog("Restored file successfull"
                + "Count restored File = {0}" + filterFiles.Count
                + "Time restored: " + DateTime.Now, Folders.LogFile);
            return true;
        }
    }
}
