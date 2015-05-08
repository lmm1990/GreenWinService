using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;

namespace GreenWinService.Test
{
    class Program
    {
        static void Main(string[] parameters)
        {
            Service service = new Service(new ServiceInfo("MyService"), new ServiceContext());
            if (parameters.Length > 0)
            {
                string option = parameters[0].ToLower();
                Console.WriteLine(option);
                switch (option)
                {
                    case "-console":
                        service.RunConsole();
                        return;
                    case "-install":
                        service.Install(); 
                        return;
                    case "-uninstall": 
                        service.UnInstall(); 
                        return;
                }
            }
            service.Init();
        }
    }
}