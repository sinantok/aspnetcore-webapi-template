using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Settings;
using System;
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
    }
}
