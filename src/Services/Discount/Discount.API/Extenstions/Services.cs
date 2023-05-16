

using Dapper;
using Discount.API.Data;
using Discount.API.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Profiling.Storage;
namespace Discount.API.Extenstions
{
    public static class Services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DiscountDbContext>();
            services.AddScoped<ICouponServices, CouponServices>();
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            //services.AddMemoryCache(); 
            services.AddMiniProfiler(options => {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
                options.Storage = new PostgreSqlStorage(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            }
            ).AddEntityFramework();
            

        }
    }
}
