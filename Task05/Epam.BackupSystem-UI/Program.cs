using Epam.BackupSystem_Logic.Implementation;
using Epam.BackupSystem_Logic.Tools;
using Epam.BackupSystem_Logic.Tools.constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_UI
{
    class Program
    {
        private static FileHandler handler = new FileHandler();
        private static FolderListener listener = new FolderListener();

        static void Main(string[] args)
        {
            InitDepencies();
            listener.RunListen(Folders.Storage, "*.txt", Helpers.FilesChangeEvent);
            //File.Copy(@"storage\txt.txt",@"backup\txt_file.txt");
         }

        private static void InitDepencies()
        {
            handler.CheckExistFolder(Folders.Storage);
            handler.CheckExistFolder(Folders.Backup);
            handler.CheckExistFolder(Folders.Config);

            if (!File.Exists(Folders.LogFile))
                File.Create(Folders.LogFile);
        }
    }
}
