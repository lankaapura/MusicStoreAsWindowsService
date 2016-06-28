using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.ServiceProcess;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Debugger.IsAttached || args.Contains("--debug"))
            {
                var host = new WebHostBuilder()
                                .UseKestrel()
                                .UseContentRoot(Directory.GetCurrentDirectory())
                                .UseIISIntegration()
                                .UseStartup<Startup>()
                                .Build();

                host.Run();
            }
            else
            {
                var exePath= System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                var directoryPath = Path.GetDirectoryName(exePath);
                var host = new WebHostBuilder()
                                .UseKestrel()
                                .UseContentRoot(directoryPath)
                                .UseStartup<Startup>()
                                .UseUrls("http://+:5050")
                                .Build();
                     //http://stackoverflow.com/a/37464074/857956 we could use either of following methods           
                    //host.RunAsService();
                    host.RunAsCustomService();
            }
        }
    }

public static class CustomWebHostWindowsServiceExtensions
{
    public static void RunAsCustomService(this IWebHost host)
    {
        var webHostService = new CustomWebHostService(host);
        ServiceBase.Run(webHostService);
    }
}
    internal class CustomWebHostService : WebHostService
{
    public CustomWebHostService(IWebHost host) : base(host)
    {
    }

    protected override void OnStarting(string[] args)
    {
        // Log
        base.OnStarting(args);
    }

    protected override void OnStarted()
    {
        // More log
        base.OnStarted();
    }

    protected override void OnStopping()
    {
        // Even more log
        base.OnStopping();
    }
}
}
