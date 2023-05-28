using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ordering.Application;
using Ordering.Application.Behaviours;
using Ordering.Application.Models;
using Ordering.Infrastructure.SqlServer;

namespace Ordering.API.Extensions
{
    public static class services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {         
            services.Configure<AppIdentitySettings>(configuration.GetSection("AppIdentitySettings"));

            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
        }
    }
}
