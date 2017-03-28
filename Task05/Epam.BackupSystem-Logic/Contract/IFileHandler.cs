using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Contract
{
    public interface IFileHandler
    {
        void FileWriter(string message,string filePath);
        void FileBackupCopy(string sourcePath,string destinationPath);
        void FileStorageCopy(string sourcePath, string destinationPath);
        List<string> GetFilesByDate(DateTime date);
        void CheckExistFolder(string folder);
    }
}