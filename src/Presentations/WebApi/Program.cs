using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var configuration = services.GetRequiredService<IConfiguration>();
                //--------------------------------------------------------------------------------
                Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "WebApi")
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                // .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .WriteTo.Seq(configuration.GetSection("Logging:Seq:Url").Value)
                //.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(""))
                //{
                //    AutoRegisterTemplate = true,
                //    OverwriteTemplate = true,
                //    DetectElasticsearchVersion = true,
                //    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                //    NumberOfReplicas = 1,
                //    IndexFormat = "serilog-application-{0:yyyy.MM.dd}",
                //    NumberOfShards = 2,
                //    RegisterTemplateFailure = RegisterTemplateRecovery.FailSink,
                //    FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                //    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                //                       EmitEventFailureHandling.WriteToFailureSink |
                //                       EmitEventFailureHandling.RaiseCallback

                //})
                .MinimumLevel.Verbose()
                .CreateLogger();

                //--------------------------------------------------------------------------------
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                    await DefaultRoles.SeedAsync(roleManager);
                    await DefaultSuperAdmin.SeedAsync(userManager);
                }
                catch { }
                finally { }
            }
            try
            {
                Log.Information("Application Start");
                host.Run();
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "Application Start-up Failed");
            }



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
