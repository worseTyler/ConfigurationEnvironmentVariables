using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args);


            IConfigurationRoot config = builder.Build();

            IConfigurationSection section = config.GetSection("Config");

            IEnumerable<IConfigurationSection> group = section.GetChildren();

            foreach (IConfigurationSection item in group)
            {
                Console.WriteLine(item.Value.ToString());
            }

            Console.WriteLine(config.GetSection("Config:WindowSize").Value.ToString());

            // The precedence of the environment variables is the same as the order
            // in which they are added to the configuration builder
            
            // dotnet run Config:WindowSize=Rome --Config:AppName=Paris
        }
    }

}
