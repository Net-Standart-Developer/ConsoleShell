using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class WHOISCommand : Command
    {
        public const string RAWCOMMAND = "WHOIS";

        protected readonly Storage storage;

        public WHOISCommand(string rawCommand, string[] operands) : base(CommandType.WHOIS, rawCommand, operands)
        {
            storage = Storage.GetInstance();    
        }

        public override string Execute()
        {
            return storage["UserName"] + ConsoleDecorator.DEFAULT_LINE_SEPARATOR;
        }
    }
}
