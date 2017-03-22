using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Contract
{
    public interface IListener
    {
        void RunListen(string folder,string extensionFilter,Action<object, FileSystemEventArgs> changedFile);
    }
}
