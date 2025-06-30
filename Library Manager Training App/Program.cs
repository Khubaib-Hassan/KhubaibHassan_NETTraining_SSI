using Library_Manager_Training_App.Models;
using Library_Manager_Training_App.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Library_Manager_Training_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();

            services.Configure<AppOptions>(config.GetSection("AppOptions"));

            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddSingleton<IDeserializeService, DeserializeService>();
            services.AddSingleton<Runner>();

            var provider = services.BuildServiceProvider();

            var runner = provider.GetService<Runner>();
            runner?.Run();

        }
    }
}
