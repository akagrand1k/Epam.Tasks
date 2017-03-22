using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Tools.constants
{
    public static class Folders
    {
        public static string Storage { get { return "storage"; } }

        public static string Config { get { return "config"; } }

        public static string Backup { get { return "backup"; } }

        public static string LogFile { get { return @"config\log.ini"; } }
    }
}