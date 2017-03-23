using Epam.BackupSystem_Logic.Tools;
using Epam.BackupSystem_Logic.Tools.constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Implementation
{
    public class RollBack
    {
        private static FileHandler handler = new FileHandler();
        private static Logger logger = new Logger();

        /// <summary>
        /// Rollback files by date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool RoolBackChange(DateTime date)
        {
            var filterFiles = handler.GetFilesByDate(date);
            FileInfo info = null;
            foreach (var item in filterFiles)
            {
                info = new FileInfo(item);
                handler.FileStorageCopy(item, Folders.Storage + @"\" + info.Name);
            }
            logger.SendLog("Restored file successfull.  "
                + " Count restored File = " + filterFiles.Count, Folders.LogFile);
            return true;
        }
    }
}
