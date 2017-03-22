using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Contract
{
    public interface IFileHandler
    {
        void FileCopy(string sourcePath,string destinationPath);
        void FileWriter(string message,string filePath);
        void CheckExistFolder(string folder);
    }
}