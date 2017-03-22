using Epam.BackupSystem_Logic.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.BackupSystem_Logic.Tools
{
    public class Logger : ILogger
    {
        public void SendLog(string message, string file)
        {
            if (string.IsNullOrWhiteSpace(message) || string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException();
            message = message + ";    Event time: "+ DateTime.Now + Environment.NewLine;
            File.AppendAllText(file,message);
        }
    }
}