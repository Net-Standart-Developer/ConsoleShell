using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public abstract class Command
    {
        public CommandType Type { get; private set; }
        public string RawCommand { get; private set; }
        public string[] Operands { get; private set; }

        public Command(CommandType type, string rawCommand, string[] operands)
        {
            this.Type = type;
            this.RawCommand = rawCommand;
            this.Operands = operands;
        }

        public abstract string Execute();
    }

    public enum CommandType
    {
        LS,
        PW,
        WHOIS,
        CD,
        RM,
        CREATE,
        NANO,
        NULL
    }
}
