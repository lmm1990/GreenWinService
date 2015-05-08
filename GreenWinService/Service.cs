using System;
using System.ServiceProcess;

namespace GreenWinService
{
    public class Service
    {
        public IServiceContext ServiceContext;

        public Service(ServiceInfo serviceInfo, IServiceContext serviceContext)
        {
            ServiceInfo = serviceInfo;
            ServiceContext = serviceContext;
        }

        public ServiceInfo ServiceInfo { get; private set; }


        public void RunConsole()
        {
            ServiceContext.Run();
        }


        public void Install()
        {
            WinServiceInstaller.Install(ServiceInfo);
        }

        public void UnInstall()
        {
            WinServiceInstaller.UnInstall(ServiceInfo);
        }

        public void Init()
        {
            ServiceBase.Run(new InternalService(this));
        }
    }
}