using System;
using System.Collections.Generic;

namespace Epam.BackupSystem_Logic.Contract
{
    public interface IFileHandler
    {
        void FileBackupCopy(string sourcePath,string destinationPath);
        void FileStorageCopy(string sourcePath, string destinationPath);
        List<string> GetFilesByDate(DateTime date);
        void CheckExistFolder(string folder);
    }
}