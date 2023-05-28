using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence.Repository;
using Ordering.Application.Contracts.Persistence.Repository.Base;
using Ordering.Application.Models;
using Ordering.Infrastructure.Core;
using Ordering.Infrastructure.Core.Mail;
using Ordering.Infrastructure.SqlServer.Persistence;
using Ordering.Infrastructure.SqlServer.Repository;
using Ordering.Infrastructure.SqlServer.Repository.Base;

namespace Ordering.Infrastructure.SqlServer
{
    public static class InfrastructureServiceRegistration
    {
        public static     IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            //services.AddSingleton<DapperContext>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddInfrastructureCoreServices(configuration);
          
            //var logger = services.GetService<ILogger<OrderContextSeed>>();
            //OrderContextSeed
            //    .SeedAsync(context, logger)
            //    .Wait();
            //services.AddScoped<SeedAsync>();

            return services;
        }
    }
    
}
