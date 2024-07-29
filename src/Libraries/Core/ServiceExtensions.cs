using Core.Interfaces;
using Core.Services;
using Data.Contexts;
using Data.Repos;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Models.Settings;
using Services.Concrete;
using Services.Interfaces;
using System.Collections.Generic;

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
            services.AddTransient<IDbContext, ApplicationDbContext>();
            
            // Ensure the database is created.
            using var context = services.BuildServiceProvider().GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();
        }
        public static void AddRepoServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<INoteService, NoteService>();

            services.AddTransient<ILoginLogService, LoginLogService>();
        }
        public static void AddCustomSwagger(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.<br><br> 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      <br><br>Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                    }
                });

            });
        }
    }
}
