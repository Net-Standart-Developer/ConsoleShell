using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Events
{
    public delegate bool ServiceStartedDel(object sender, ServiceStartedEventArgs e);
    public class ServiceStartedEventArgs
    {
        public string User { get; private set; }
        public string Path { get; private set; }
        public bool StartSuccess { get; private set; }

        public ServiceStartedEventArgs(string user, string path, bool startSuccess)
        {
            User = user;
            Path = path;
            StartSuccess = startSuccess;
        }
    }
}
