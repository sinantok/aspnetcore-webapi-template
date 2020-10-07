using Core.Interfaces;
using Core.Services;
using Data.Contexts;
using Models.Settings;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddSharedServices(this IServiceCollection services, IConfiguration config)
        {
            #region Configure
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            #endregion

            #region Services
            services.AddTransient<IEmailService, EmailService>();
            #endregion
        }
        public static void AddApplicationSqlServer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
