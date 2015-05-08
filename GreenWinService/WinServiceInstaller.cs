using System;
using System.Collections;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace GreenWinService
{
    internal static class WinServiceInstaller
    {
        public static void Install(ServiceInfo serviceInfo)
        {
            Install(true,serviceInfo);
        }

        public static void UnInstall(ServiceInfo serviceInfo)
        {
            Install(false, serviceInfo);
        }

        private static Installer CreateInstaller(ServiceInfo serviceInfo)
        {
            Installer installer = new Installer();

            ServiceInstaller serviceInstaller = new ServiceInstaller();
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();

            serviceInstaller.Description = serviceInfo.Description;
            serviceInstaller.StartType = serviceInfo.ServiceStartMode;
            serviceInstaller.DisplayName = serviceInfo.DisplayName;
            serviceInstaller.ServiceName = serviceInfo.ServiceName;
            serviceInstaller.DelayedAutoStart = true;//延迟启动

            if (serviceInfo.DependsOn != null && serviceInfo.DependsOn.Length > 0)
                serviceInstaller.ServicesDependedOn = serviceInfo.DependsOn;

            serviceProcessInstaller.Account = serviceInfo.ServiceAccount;
            serviceProcessInstaller.Username = serviceInfo.UserName;
            serviceProcessInstaller.Password = serviceInfo.Password;

            installer.Installers.Add(serviceProcessInstaller);
            installer.Installers.Add(serviceInstaller);

            return installer;
        }

        private static void Install(bool install, ServiceInfo serviceInfo)
        {
            using (TransactedInstaller transactedInstaller = new TransactedInstaller())
            {
                using (Installer installer = CreateInstaller(serviceInfo))
                {
                    transactedInstaller.Installers.Add(installer);

                    string path = string.Format("/assemblypath={0}", Assembly.GetEntryAssembly().Location);

                    transactedInstaller.Context = new InstallContext("", new[] { path });

                    if (install)
                    {
                        transactedInstaller.Install(new Hashtable());
                        ServiceController service = new ServiceController(serviceInfo.ServiceName);
                        if (service.Status != ServiceControllerStatus.Running && service.Status != ServiceControllerStatus.StartPending)
                        {
                            service.Start();
                        }
                        return;
                    }
                    transactedInstaller.Uninstall(null);
                }
            }
        }
    }
}