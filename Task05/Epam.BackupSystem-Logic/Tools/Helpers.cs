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

        /// <summary>
        /// For renamed files proccessing backup
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>

        public static string DateTimeFormat(DateTime date)
        {
            return DateTime.Now.ToString("dd.MM.yy H.mm");
        }
        
        /// <summary>
        /// Try parse custom date
        /// </summary>
        /// <param name="str"></param>
        /// <returns>DateTime</returns>
        public static DateTime DateParse(string str)
        {
            DateTime dt = DateTime.MinValue;
            dt = DateTime.ParseExact(str, "dd.MM.yyyy HH:m", null);
            return dt;
        }

        public static void FilesChangeEvent(object sender,FileSystemEventArgs e)
       { 
            Console.WriteLine("File changed: " + e.Name + " " + e.ChangeType);
            logger.SendLog("File changed: " + e.Name + " " + e.ChangeType, Folders.LogFile);

            handler.FileBackupCopy(Folders.Storage + @"\" + e.Name, Folders.Backup);

        }
    }
}