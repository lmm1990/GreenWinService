# GreenWinService

绿色简洁的windows服务安装中间件
	
## 使用
	
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