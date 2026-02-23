using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class NullCommand : Command
    {
        public NullCommand(string rawCommand, string[] operands) : base(CommandType.NULL, rawCommand, operands)
        {

        }

        public override string Execute()
        {
            return "";
        }
    }
}
