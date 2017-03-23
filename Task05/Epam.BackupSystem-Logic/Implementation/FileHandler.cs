using Epam.BackupSystem_Logic.Contract;
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
    public class FileHandler : IFileHandler
    {
        public void CheckExistFolder(string folder)
        {
            if (string.IsNullOrWhiteSpace(folder))
                throw new ArgumentException(folder);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
        
        public void FileBackupCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException();

            File.Copy(sourcePath, RenameFileByDate(sourcePath,destinationPath));
        }
        
        public void FileStorageCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException();

            File.Copy(sourcePath, RemoveDateInName(destinationPath),true);
        }

        public void FileWriter(string message, string filePath)
        {
            if (string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException();
            message = message + Environment.NewLine;
            File.AppendAllText(filePath, message, Encoding.Default);
        }

        public List<string> GetFilesByDate(DateTime date)
        {
            FileInfo info = null;
            var allfiles = Directory.GetFiles(Folders.Backup);
            List<string> temp = new List<string>();
            foreach (var item in allfiles)
            {
                info = new FileInfo(item);
                if (info.LastWriteTime <= date)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        private string RemoveDateInName(string str)
        {
            FileInfo info = new FileInfo(str);
            var temp = str.Remove(str.IndexOf("_backup_")) + info.Extension;
            return temp;
        }

        private string RenameFileByDate(string sourcePath,string destinationPath)
        {
            FileInfo info = new FileInfo(sourcePath);

            var newFileName = Directory.GetParent(info.Name) + @"\" + destinationPath + @"\" + 

                Path.GetFileNameWithoutExtension(info.Name) + "_backup_" + Helpers.DateTimeFormat(DateTime.Now) + info.Extension;

            return newFileName;
        }
    }
}
