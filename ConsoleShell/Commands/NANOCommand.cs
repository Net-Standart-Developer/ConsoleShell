using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleShell.Commands
{
    public class NANOCommand : Command
    {
        public const string RAWCOMMAND = "NANO";

        protected readonly Storage storage;

        public NANOCommand(string rawCommand, string[] operands) : base(CommandType.NANO, rawCommand, operands)
        {
            storage = Storage.GetInstance();
        }

        public override string Execute()
        {
            string[] fileParts = new string[Operands.Length + 1];
            fileParts[0] = storage["Path"];
            for(int i = 0; i < Operands.Length; i++)
            {
                fileParts[i + 1] = Operands[i];
            }

            string nanoFile = Path.Combine(fileParts);
            if (Path.IsPathFullyQualified(nanoFile))
            {
                var psi = new ProcessStartInfo(nanoFile);
                psi.UseShellExecute = true;
                Process.Start(psi);
            }

            return "";
        }
    }
}
