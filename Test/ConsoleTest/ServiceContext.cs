using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreenWinService;

namespace GreenWinService.Test
{
    class ServiceContext : IServiceContext
    {
        public void Run()
        {
            System.IO.File.AppendAllText("d:/a.txt",string.Format("start time:{0}\r\n\r\n ",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        public void OnStopping()
        {
            System.IO.File.AppendAllText("d:/a.txt",string.Format("end time:{0}\r\n\r\n ",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
    }
}
