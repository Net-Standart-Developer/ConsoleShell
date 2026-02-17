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
        public ConsoleShellFacade()
        {
            initializer = new Initializer();
            storage = Storage.GetInstance();
        }

        public async Task<bool> Start()
        {
            await Task.Run(() =>
            {
                bool initialStarted = initializer.Start();
                if (initialStarted)
                {
                    string userName = initializer.UserName;
                    string path = initializer.Path;
                    storage["UserName"] = userName;
                    storage["Path"] = path;

                    ServiceStarting?.Invoke(this, new ServiceStartingEventArgs(userName, path));

                    while (true)
                    {
                        ConsoleDecorator.ReadLine(path + ">", TextType.Usual);

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
