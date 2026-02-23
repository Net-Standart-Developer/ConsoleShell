using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class PWCommand : Command
    {
        public const string RAWCOMMAND = "PW";

        protected readonly Storage storage;
        public PWCommand(string rawCommand, string[] operands) : base(CommandType.PW, rawCommand, operands) 
        {
            storage = Storage.GetInstance();
        }
        public override string Execute()
        {
            return storage["Path"] + ConsoleDecorator.DEFAULT_LINE_SEPARATOR;
        }
    }
}
