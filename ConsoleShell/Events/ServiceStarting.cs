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
        public ServiceStartingEventArgs()
        {

        }
    }
}
