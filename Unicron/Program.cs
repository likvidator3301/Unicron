using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Vostok.Logging.Console;
using Vostok.Logging.Microsoft;

namespace Unicron
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(CofigureLogging)
                .UseStartup<Startup>();
        }

        private static void CofigureLogging(ILoggingBuilder loggingBuilder)
        {
            var consoleLog = new ConsoleLog(
                new ConsoleLogSettings
                {
                    ColorsEnabled = true
                });
            loggingBuilder.AddProvider(new VostokLoggerProvider(consoleLog));
        }
    }
}
