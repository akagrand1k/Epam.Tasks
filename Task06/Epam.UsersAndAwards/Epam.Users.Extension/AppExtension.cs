using Epam.Users.Constants;
using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Extension
{
    public static class AppExtension
    {
        /// <summary>
        /// Check file exist,if don't exist create then.
        /// </summary>
        public static void CheckSystemFolder()
        {
            if (!Directory.Exists(AppConst.ConfigFolder) ||
                !Directory.Exists(AppConst.StorageFolder))
            {
                Directory.CreateDirectory(AppConst.StorageFolder);
                Directory.CreateDirectory(AppConst.ConfigFolder);
            }
        }

        /// <summary>
        /// Check file exist,if don't exist create then.
        /// </summary>
        public static void CheckSystemFile()
        {
            var paths = new[] { AppConst.logPath, AppConst.dataPath ,AppConst.awardsPath };
            List<string> createPaths = new List<string>();

            foreach (var path in paths)
            {
                if (!File.Exists(path))
                {
                    createPaths.Add(path);
                }
            }

            foreach (var item in createPaths)
            {
                var files = File.Create(item);
                files.Close();
            }
        }

        public static DateTime DateFormat(DateTime date)
        {
            DateTime dt = DateTime.MinValue;
            dt = DateTime.ParseExact(date.ToString(),"dd.MM.yyyy",null);

            return dt;
        }

        public static DateTime DateFormat(string date)
        {
            DateTime dt = DateTime.MinValue;
            dt = DateTime.ParseExact(date, "dd.MM.yyyy", null);

            return dt;
        }

        public static IEnumerable<string> GetUserHeader
        {
            get
            {
                var properties = typeof(User).GetProperties();
                return properties.Select(x => x.Name).ToArray();
            }
        }

        public static IEnumerable<string> GetAwardsProperty
        {
            get
            {
                return typeof(User).GetProperties().Select(x => x.Name).ToArray();
            }
        }
    }
}
