using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public class ApplicationConfigurations
    {
        
        public ApplicationConfigurations()
        {
            var appConfiguration = new ConfigurationBuilder()
                .SetBasePath(_directory)
                .AddJsonFile(@"CORE/AppSettings.json")
                .Build();
            Log = appConfiguration["ConnectionStrings:Log"];
            Languages = Path.Combine(_directory,@"CORE/Languages",appConfiguration["ConnectionStrings:Languages"]);
            Icon = Path.Combine(_directory,@"CORE/Resources",appConfiguration["ConnectionStrings:Icon"]);
        }

        private static IConfiguration AppConfiguration { get; set; }

        private readonly string _directory = Directory.GetParent(Directory
                .GetParent(Directory
                    .GetParent(Directory
                        .GetParent(Directory
                            .GetCurrentDirectory())
                        .ToString())
                    .ToString())
                .FullName)
            .ToString();
        
        public string Log { get; }

        public string Languages { get; }
        
        public string Icon { get; }

    }
}