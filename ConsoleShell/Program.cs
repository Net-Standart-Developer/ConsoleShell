namespace ConsoleShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ConsoleShellFacade service = new ConsoleShellFacade())
            {
                Task<bool> process;
                if ((process = service.Start()).Result)
                {
                    ConsoleDecorator.WriteLine("Ошибка при запуске оболочки", TextType.Critical);
                    
                }   
            }
        }
    }
}
