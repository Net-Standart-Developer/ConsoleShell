using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class RMCommand : Command
    {
        public const string RAWCOMMAND = "RM";

        private readonly Storage storage;

        public RMCommand(string rawCommand, string[] operands) : base(CommandType.RM, rawCommand, operands)
        {
            storage = Storage.GetInstance();
        }

        public override string Execute()
        {
            string[] directoryForRM = new string[this.Operands.Length + 1];
            directoryForRM[0] = this.storage["Path"];

            for(int i = 0; i < Operands.Length; i++)
            {
                directoryForRM[i + 1] = Operands[i];
            }

            string deletingDirectory = Path.Combine(directoryForRM);
            if (Directory.Exists(deletingDirectory))
            {
                Directory.Delete(deletingDirectory, true);
                return "Директория успешно удалена.";
            }

            deletingDirectory = Path.Combine(Operands);
            if (Directory.Exists(deletingDirectory))
            {
                Directory.Delete(deletingDirectory, true);
                return "Директория успешно удалена.";
            }

            return "Нет такой директории.";

        }
    }
}
