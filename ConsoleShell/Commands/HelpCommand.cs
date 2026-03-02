using ConsoleShell.MyStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShell.Commands
{
    public class HelpCommand : Command
    {
        public const string RAWCOMMAND = "HELP";

        protected readonly Storage storage;

        public HelpCommand(string rawCommand, string[] operands) : base(CommandType.HELP, rawCommand, operands)
        {
            storage = Storage.GetInstance();
        }

        public override string Execute()
        {
            return $"===============HELP==================" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR +
                   $"1. ls - просмотр списка файлов для текущего пути" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR +
                   $"2. whois - просмотр текущего пользователя" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR +
                   $"3. cd - изменение рабочей директории" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR +
                   $"4. rm - удаление файла или папки" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR +
                   $"5. create - создание папки" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR +
                   $"6. nano - редактирование файла" + ConsoleDecorator.DEFAULT_LINE_SEPARATOR;
        }
    }
}
