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

       private const string LogFile = "log.txt";
       private const string DataStorageFile = "Users.csv";
       private const string AwardStorageFile = "Awards.csv";
       private const string UserAwards = "UserAwards.csv";

        public const string logPath = ConfigFolder + @"\" + LogFile;
        public const string dataPath = StorageFolder + @"\" + DataStorageFile;
        public const string awardsPath = StorageFolder + @"\" + AwardStorageFile;
        public const string userAwardsPath = StorageFolder + @"\" + UserAwards;
    }
}