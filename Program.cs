using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace II
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
                .UserIISlntegration()
                .Build();

            host.Run();
        }
    }
}
