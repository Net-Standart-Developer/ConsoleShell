using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class CreateCommand : Command
    {
        public const string RAWCOMMAND = "CREATE";

        protected readonly Storage storage;

        public CreateCommand(string rawCommand, string[] operands) : base(CommandType.RM, rawCommand, operands)
        {
            this.storage = Storage.GetInstance();
        }

        public override string Execute()
        {
            string[] subDirectories = new string[this.Operands.Length + 1];
            subDirectories[0] = this.storage["Path"];
            for(int i = 0; i < Operands.Length; i++)
            {
                subDirectories[i + 1] = Operands[i];
            }

            string creatingDirectory = Path.Combine(subDirectories);
            if (!Directory.Exists(creatingDirectory))
            {
                Directory.CreateDirectory(creatingDirectory);
                return "Директория успешно создана.";
            }
            else
            {
                return "Директория уже существует.";
            }
        }
    }
}
