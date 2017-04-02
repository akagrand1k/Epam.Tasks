using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Constants
{
    public static class AppConst
    {
        public const string ConfigFolder = "Config";
        public const string StorageFolder = "FileStorage";

        public const string LogFile = "log.txt";
        public const string DataStorageFile = "Users.csv";
        public const string AwardStorageFile = "Awards.csv";


        public const string logPath = ConfigFolder + @"\" + LogFile;
        public const string dataPath = StorageFolder + @"\" + DataStorageFile;
        public const string awardsPath = StorageFolder + @"\" + AwardStorageFile;

        //public static string[] AwardsList
        //{
        //    get
        //    {
        //        return new string[] { "Golden", "Silver", "Bronze" };
        //    }
        //}
    }
}
