using Epam.BackupSystem_Logic.Implementation;
using Epam.BackupSystem_Logic.Tools.constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Tools
{
    public static class Helpers
    {
        private static Logger logger = new Logger();
        private static FileHandler handler = new FileHandler();

        public static string DateTimeFormat(DateTime date)
        {
            return DateTime.Now.ToString("dd.MM.yy H.mm");
        }

        public static void FilesChangeEvent(object sender,FileSystemEventArgs e)
       { 
            Console.WriteLine("File changed: " + e.Name + " " + e.ChangeType);
            logger.SendLog("File changed: " + e.Name + " " + e.ChangeType, Folders.LogFile);
            handler.FileCopy(Folders.Storage + @"\" + e.Name, Folders.Backup);
        }
    }
}