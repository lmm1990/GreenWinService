using System;

namespace GreenWinService
{
    public interface IServiceContext
    {
        void Run();

        void OnStopping();
    }
}
