using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class CommandParser
    {
        public CommandParser()
        {

        }

        public Command? ParseCommand(string rawCommand)
        {
            string[] data = rawCommand.Split(ConsoleDecorator.DEFAULT_SEPARATOR);
            string[] operands = new string[data.Length - 1];
            
            for (int i = 1; i < data.Length; i++)
            {
                operands[i - 1] = data[i];
            }

            switch (data[0].ToUpper())
            {
                case LSCommand.RAWCOMMAND:        
                    return new LSCommand(data[0], operands);
                case PWCommand.RAWCOMMAND:
                    return new PWCommand(data[0], new string[] { });
                case WHOISCommand.RAWCOMMAND:
                    return new WHOISCommand(data[0], new string[] { });
                case CDCommand.RAWCommand:
                    return new CDCommand(data[0], operands);
                case RMCommand.RAWCOMMAND:
                    return new RMCommand(data[0], operands);
                case CreateCommand.RAWCOMMAND:
                    return new CreateCommand(data[0], operands);
                case NANOCommand.RAWCOMMAND:
                    return new NANOCommand(data[0], operands);
                case "":
                    return new NullCommand(data[0], new string[] { });
            }

            return null;
        }
    }
}
