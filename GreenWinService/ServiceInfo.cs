using System;
using System.ServiceProcess;

namespace GreenWinService
{
    public class ServiceInfo
    {
        public string DisplayName { get; set; }
        public string ServiceName { get; set; }
        public ServiceAccount ServiceAccount { get; set; }
        public ServiceStartMode ServiceStartMode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] DependsOn { get; set; }
        public string Description { get; set; }

        public ServiceInfo(string serviceName)
        {
            ServiceStartMode = ServiceStartMode.Automatic;
            ServiceAccount = ServiceAccount.LocalSystem;
            ServiceName = serviceName;
        }

        public ServiceInfo(string serviceName, string displayName) : this(serviceName)
        {
            DisplayName = displayName;
        }
    }
}