namespace ConsoleShell
{
    public class ConsoleShellFacade : IService
    {
        public ConsoleShellFacade()
        {

        }

        public async Task<bool> Start()
        {
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
