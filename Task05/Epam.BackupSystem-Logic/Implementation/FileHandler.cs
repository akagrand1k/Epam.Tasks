using Epam.BackupSystem_Logic.Contract;
using Epam.BackupSystem_Logic.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Implementation
{
    public class FileHandler : IFileHandler
    {
        public void CheckExistFolder(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
                throw new ArgumentException(folder);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        public void FileCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException();

            File.Copy(sourcePath, RenameFileByDate(sourcePath,destinationPath));
        }

        public void FileWriter(string message, string filePath)
        {
            if (string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException();
            message = message + Environment.NewLine;
            File.AppendAllText(filePath, message, Encoding.Default);
        }

        private string RenameFileByDate(string sourcePath,string destinationPath)
        {
            FileInfo info = new FileInfo(sourcePath);

            var newFileName = Directory.GetParent(info.Name) + @"\" + destinationPath + @"\" + 
                Path.GetFileNameWithoutExtension(info.Name) + "_" + Helpers.DateTimeFormat(DateTime.Now) + info.Extension;

            return newFileName;
        }
    }
}
