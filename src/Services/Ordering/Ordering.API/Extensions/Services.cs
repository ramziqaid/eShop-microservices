using Ordering.API.EventBusConsumer;
using Ordering.Application;
using Ordering.Application.Models;
using Ordering.Infrastructure.SqlServer;
using System.Reflection;

namespace Ordering.API.Extensions
{
    public static class services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {         
            services.Configure<AppIdentitySettings>(configuration.GetSection("AppIdentitySettings"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration); 
        }
    }
}
