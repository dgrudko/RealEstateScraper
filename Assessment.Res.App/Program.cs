using Assessment.Res.App.Configs;
using Microsoft.Extensions.Hosting;
using System;
using Topshelf;

namespace Assessment.Res.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Bootstrapper.GetServiceProvider();
            
            HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<ResWindowsService>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => (ResWindowsService)serviceProvider.GetService(typeof(ResWindowsService)));
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());
                });
            });
            Console.WriteLine("Hello World!");
        }
    }
}
