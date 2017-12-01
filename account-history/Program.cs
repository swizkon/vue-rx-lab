﻿using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AccountHistory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "public"))
                .UseStartup<Startup>()
                .Build();
    }
}
