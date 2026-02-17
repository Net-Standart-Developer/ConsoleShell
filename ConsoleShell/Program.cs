namespace ConsoleShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ConsoleShellFacade service = new ConsoleShellFacade())
            {
                if (!service.Start())
                {
                    ConsoleDecorator.WriteLine("Ошибка при запуске оболочки", TextType.Critical);
                }
            }
        }
    }
}
