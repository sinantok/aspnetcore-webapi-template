using Caching;
using Core;
using GraphiQl;
using HealthChecks.UI.Client;
using Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Services.Interfaces;
using WebApi.Extensions;
using WebApi.GraphQL;
using WebApi.Helpers;
using WebApi.Services;
using AutoMapper;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity(Configuration);
            services.AddSharedServices(Configuration);
            services.AddApplicationSqlServer(Configuration);
            services.AddRepoServices(Configuration);
            services.AddAppServices(Configuration);
            services.AddGraphQLServices(Configuration);
            services.AddRedis(Configuration); //TODO: redisHealtCheck
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();
                //.AddNewtonsoftJson(options =>
                //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                //);

            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("IdentityConnection"),
                name: "identityDb-check",
                failureStatus: HealthStatus.Unhealthy,
                tags: new string[] { "api", "SqlDb" })
                .AddSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                name: "applicationDb-check",
                failureStatus: HealthStatus.Unhealthy,
                tags: new string[] { "api", "SqlDb" });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseGraphiQl();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseErrorHandlingMiddleware();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
