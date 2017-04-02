using Epam.Users.Constants;
using Epam.Users.DAOContracts;
using Epam.Users.Entities;
using Epam.Users.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.FileDAL
{
    public class FileHandler
    {
        /// <summary>
        /// Write c
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CSVWriter(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            var writeMessage = $"{user.Id = GetMaxId() + 1 };{user.Name};{user.DateOfBirth.ToShortDateString()};{user.Age}" + Environment.NewLine;
            File.AppendAllText(AppConst.dataPath,writeMessage
                ,Encoding.Default);
            ReWriteId(user.Id);
            return true;
        }

        /// <summary>
        /// Rewrite id after create new entity
        /// </summary>
        /// <param name="Id"></param>
        private void ReWriteId(int Id)
        {
            string[] lines = File.ReadAllLines(AppConst.dataPath,Encoding.Default);
            lines[1] = $"{Id}";
            File.WriteAllLines(AppConst.dataPath, lines, Encoding.Default);
        }

        /// <summary>
        /// Write static header files,First row - model property.
        /// </summary>
        public void WriteHeader()
        {
            var temp = string.Empty;
            foreach (var item in AppExtension.GetHeader)
            {
                temp += item + ";";
            }
            var isNull = File.ReadAllLines(AppConst.dataPath);
            if (isNull.Length == 0)
            {
                File.AppendAllLines(AppConst.dataPath, new[] { temp }
                , Encoding.Default);
                File.AppendAllLines(AppConst.dataPath, new[] { "0" });
            }
        }

        /// <summary>
        /// Read all entity in storage
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> ReadAllEntity()
        {
            var file = File.ReadAllLines(AppConst.dataPath,Encoding.Default).Skip(2);
            return file
           .Select(x => x.Split(';'))
           .Select(z => new User
           {
               Id = int.Parse(z[0]),
               Name = z[1],
               DateOfBirth = AppExtension.DateFormat(z[2]),
               Age = int.Parse(z[3]),
           });
        }

        public bool DeleteUserByName(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            var allLines = File.ReadAllLines(AppConst.dataPath,Encoding.Default);
            var newLines = allLines.Where(x => !x.Contains(user.Name));
            File.WriteAllLines(AppConst.dataPath, newLines,Encoding.Default);
            return true;
        }

        /// <summary>
        /// Get MaxId Entity in file
        /// </summary>
        /// <returns></returns>
        private int GetMaxId()
        {
            return int.Parse(File.ReadAllLines(AppConst.dataPath).Skip(1).First());
        }
    }
}
