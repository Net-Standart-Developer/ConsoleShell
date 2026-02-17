using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.MyStorage
{
    public class Storage
    {
        private static Storage instance { get; set; }

        private IDictionary<string, string> _storage;
        private Storage()
        {
            _storage = new Dictionary<string, string>();
        }

        public static Storage GetInstance()
        {
            if(instance == null)
            {
                instance = new Storage();
            }

            return instance;
        }

        public string this[string key]
        {
            get
            {
                return _storage[key];
            }
            set
            {
                _storage[key] = value;
            }
        }
    }
}
