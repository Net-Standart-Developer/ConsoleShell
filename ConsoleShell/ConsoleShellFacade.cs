using ConsoleShell.Commands;
using ConsoleShell.Events;
using ConsoleShell.Initialization;
using ConsoleShell.MyStorage;

namespace ConsoleShell
{
    public class ConsoleShellFacade : IService
    {
        public event ServiceStartingDel? ServiceStarting;
        public event ServiceStartedDel? ServiceStarted;

        private readonly Initializer initializer;
        private readonly Storage storage;
        private readonly CommandParser parser;
        public ConsoleShellFacade()
        {
            initializer = new Initializer();
            storage = Storage.GetInstance();
            parser = new CommandParser();
        }

        public async Task<bool> Start()
        {
            await Task.Run(() =>
            {
                ServiceStarting?.Invoke(this, new ServiceStartingEventArgs());
                bool initialStarted = initializer.Start();
                
                if (initialStarted)
                {
                    string userName = initializer.UserName;
                    string path = initializer.Path;
                    storage["UserName"] = userName;
                    storage["Path"] = path;

                    ServiceStarted?.Invoke(this, new ServiceStartedEventArgs(userName, storage["Path"], initialStarted));

                    while (true)
                    {
                        string rawCommand = ConsoleDecorator.Read(storage["Path"] + ">", TextType.Usual);
                        Command? command = parser.ParseCommand(rawCommand);
                        if(command != null)
                        {
                            string commandResult = command.Execute();

                            if(command.Type != CommandType.NULL)
                                ConsoleDecorator.WriteLine(commandResult, TextType.Info);
                        }
                        else
                        {
                            ConsoleDecorator.WriteLine("Такой комманды не существует.", TextType.Error);
                        }
                    }
                }
            });
            return true;
        }

        public async Task<bool> Stop()
        {
            return true;
        }

        public void Dispose()
        {

        }
    }

    public interface IService : IDisposable
    {
        public Task<bool> Start();
        public Task<bool> Stop();
    }
}
