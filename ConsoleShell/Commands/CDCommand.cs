using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class CDCommand : Command
    {
        public const string RAWCommand = "CD";

        protected readonly Storage storage;

        public CDCommand(string rawCommand, string[] operands) : base(CommandType.CD, rawCommand, operands)
        {
            storage = Storage.GetInstance();
        }

        public override string Execute()
        {
            if (Operands.Length != 1)
            {
                return "Неверное количество операндов";
            }

            string newDirectory = "";
            if (storage["Path"].EndsWith("\\"))
            {
                newDirectory = storage["Path"] + Operands[0];
            }
            else
            {
                newDirectory = storage["Path"] + "\\" + Operands[0];
            }

            if (!Directory.Exists(newDirectory))
            {
                if (!Directory.Exists(Operands[0]))
                {
                    return "Нет такой директории";
                }
                else
                {
                    newDirectory = Operands[0];
                }
            }

            storage["Path"] = newDirectory;
            return "Путь успешно изменен";
        }
    }
}
