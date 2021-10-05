using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Data.Mongo
{
    public static class ServiceExtensions
    {
        public static void AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
