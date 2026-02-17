using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Events
{
    public delegate bool ServiceStartingDel(object sender, ServiceStartingEventArgs e);
    public class ServiceStartingEventArgs
    {
        public string User { get; private set; }
        public string Path { get; private set; }

        public ServiceStartingEventArgs(string user, string path)
        {
            User = user;
            Path = path;
        }
    }
}
