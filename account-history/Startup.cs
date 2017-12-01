using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountHistory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Console.WriteLine("Configure(IApplicationBuilder app, IHostingEnvironment env)");
            var builder = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                Console.WriteLine("");
                Console.WriteLine("env.ContentRootPath:");
                Console.WriteLine(env.ContentRootPath);
                Console.WriteLine("");

                builder.SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.local.json", optional: false)
                        .AddEnvironmentVariables();
            }

            Configuration = builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                });
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureServices(IServiceCollection services)");
            services.AddMvc();
            services.AddLogging();
        }
    }
}
