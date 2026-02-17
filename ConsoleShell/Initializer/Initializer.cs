using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Initialization
{
    public class Initializer
    {
        public const string DefaultPath = "C:\\";

        public string UserName { get; private set; }
        public string Path { get; private set; }
        public Initializer()
        {

        }

        public bool Start()
        {
            string userName = ConsoleDecorator.ReadLine("Введите имя пользователя.", TextType.Accent);
            UserName = userName;

            while (true)
            {
                string path = ConsoleDecorator.ReadLine("Введите начальный путь.", TextType.Accent);
                if (string.IsNullOrEmpty(path))
                {
                    path = DefaultPath;
                }

                if (Directory.Exists(path))
                {
                    Path = path;
                    break;
                }
                else
                {
                    ConsoleDecorator.WriteLine("Несуществующий путь.");
                }
            }

            return true;
            
        }
    }
}
