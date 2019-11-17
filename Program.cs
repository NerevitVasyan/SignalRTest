using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SignalRTest
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Task.Run(() =>
            //{

            //    while (true)
            //    {
            //        Thread.Sleep(1000);

            //        if (DateTime.Now.ToString() == "12.12.2012")
            //        {

            //        }
            //    }

            //});


            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
