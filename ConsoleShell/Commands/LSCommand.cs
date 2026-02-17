using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class LSCommand : Command
    {
        public const string RAWCOMMAND = "LS";

        protected readonly Storage storage;
        public LSCommand(string rawCommand, string[] operands) : base(CommandType.LS, rawCommand, operands)
        {
            storage = Storage.GetInstance();
        }

        public override string Execute()
        {
            StringBuilder result = new StringBuilder();

            if (Directory.Exists(storage["Path"]))
            {
                foreach (var dir in Directory.GetDirectories(storage["Path"]))
                {
                    result.Append(dir + ConsoleDecorator.DEFAULT_LINE_SEPARATOR);
                }

                foreach (var file in Directory.GetFiles(storage["Path"]))
                {
                    result.Append(file + ConsoleDecorator.DEFAULT_LINE_SEPARATOR);
                }

                return result.ToString();
            }

            return "Нет такой директории.";
        }
    }
}