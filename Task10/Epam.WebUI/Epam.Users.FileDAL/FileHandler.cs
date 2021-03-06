﻿using Epam.Users.Constants;
using Epam.Users.DAOContracts;
using Epam.Users.Entities;
using Epam.Users.Extension;
using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.FileDAL
{
    public class FileHandler : IFileDao
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
            var writeMessage = $"{user.Id = GetMaxId(AppConst.dataPath) + 1 };{user.Name};{user.DateOfBirth.ToShortDateString()};{user.Age}" + Environment.NewLine;
            File.AppendAllText(AppConst.dataPath,writeMessage
                ,Encoding.Default);
            ReWriteId(user.Id,AppConst.dataPath);
            return true;
        }

        public bool CSVWriter(Award award)
        {
            if (award == null)
                throw new ArgumentNullException();
            var writeMessage = $"{award.Id = GetMaxId(AppConst.awardsPath) + 1 };{award.Title}" + Environment.NewLine;
            File.AppendAllText(AppConst.awardsPath, writeMessage
                , Encoding.Default);
            ReWriteId(award.Id,AppConst.awardsPath);
            return true;
        }

        public bool CSVWriter(UserAwards aw)
        {
            if (aw == null)
                throw new ArgumentNullException();

            var writeMessage = $"{aw.Id = GetMaxId(AppConst.userAwardsPath) + 1 };{aw.UserId};{aw.AwardsId}" + Environment.NewLine;
            File.AppendAllText(AppConst.userAwardsPath, writeMessage
                , Encoding.Default);
            ReWriteId(aw.Id, AppConst.userAwardsPath);
            return true;
        }

        /// <summary>
        /// Rewrite id after create new entity
        /// </summary>
        /// <param name="Id"></param>
        private void ReWriteId(int Id,string file)
        {
            string[] lines = File.ReadAllLines(file,Encoding.Default);
            lines[1] = $"{Id}";
            File.WriteAllLines(file, lines, Encoding.Default);
        }

        /// <summary>
        /// Write static header files,First row - model property.
        /// </summary>
        public void WriteHeader(IEnumerable<string> header,string file)
        {
            var temp = string.Empty;
            foreach (var item in header)
            {
                temp += item + ";";
            }
            var isNull = File.ReadAllLines(file,Encoding.Default);
            if (isNull.Length == 0)
            {
                File.AppendAllLines(file, new[] { temp }
                , Encoding.Default);
                File.AppendAllLines(file, new[] { "0" });
            }
        }

        /// <summary>
        /// Read all entity in storage
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> ReadAllEntity()
        {
            var file = File.ReadAllLines(AppConst.dataPath,Encoding.Default).Skip(2);
            var result =file.Select(x => x.Split(';'))
           .Select(z => new User
           {
               Id = int.Parse(z[0]),
               Name = z[1],
               DateOfBirth = AppExtension.DateFormat(z[2]),
               Age = int.Parse(z[3]),
           });

            return result;
        }

        public IEnumerable<Award> ReadAllAwards()
        {
            return File.ReadAllLines(AppConst.awardsPath, Encoding.Default).Skip(2)
                .Select(x => x.Split(';'))
                .Select(z => new Award
                {
                    Id = int.Parse(z[0]),
                    Title = z[1]
                });
        }

        public IEnumerable<UserAwards> ReadAllUserAwards()
        {
            return File.ReadAllLines(AppConst.userAwardsPath, Encoding.Default).Skip(2)
                .Select(x => x.Split(';'))
                .Select(z => new UserAwards
                {
                    Id= int.Parse(z[0]),
                    UserId = int.Parse(z[1]),
                    AwardsId = int.Parse(z[2]),
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
        private int GetMaxId(string file)
        {
            return int.Parse(File.ReadAllLines(file).Skip(1).First());
        }
    }
}