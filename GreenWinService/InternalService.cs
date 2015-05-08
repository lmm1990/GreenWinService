using System;
using System.ServiceProcess;

namespace GreenWinService
{
    internal class InternalService : ServiceBase
    {
        private readonly Service _service;

        public InternalService(Service service)
        {
            _service = service;

            ServiceName = service.ServiceInfo.ServiceName;
        }

        protected override void OnStart(string[] args)
        {
            _service.ServiceContext.Run();
        }

        protected override void OnStop()
        {
            _service.ServiceContext.OnStopping();
        }

        protected override void OnPause()
        {
        }

        protected override void OnContinue()
        {
        }
    }
}