using System.IO;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SppdDocs.Core;

namespace SppdDocs
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
                          .ConfigureAppConfiguration((hostingContext, config) =>
                          {
                              config.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), Constants.Config.APP_CONFIG_FOLDER));
                              config.AddJsonFile("appsettings.json", false, false);
                          })
                          .ConfigureLogging((hostingContext, logging) =>
                          {
                              logging.AddLog4Net(Path.Combine(Constants.Config.APP_CONFIG_FOLDER, Constants.Config.LOG4NET_CONFIG_FILE_NAME));
                          })
                          .UseStartup<Startup>();
        }
    }
}