using MediatR;
using Microsoft.AspNetCore.Hosting;
using Ordering.Application;
using Ordering.Application.Behaviours;
using Ordering.Infrastructure.SqlServer;

namespace Ordering.API.Extensions
{
    public static class services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
        }
    }
}
