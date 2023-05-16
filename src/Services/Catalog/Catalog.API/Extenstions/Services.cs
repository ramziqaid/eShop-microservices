using Catalog.API.Data;
using Catalog.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;

namespace Catalog.API.Extenstions
{
    public static class Services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICatalogDbContext, CatalogDbContext>();
            services.AddScoped<IProductService, ProductService>();
            // Auto Mapper Configurations
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging(builder =>
            {
                builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddFile(o => o.RootPath = AppContext.BaseDirectory);
            });
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
                options.Storage = new MongoDbStorage(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            }
                   ).AddEntityFramework();

            //using (var sp = services.BuildServiceProvider())
            //{
            //    var loggerFactory = sp.GetService<ILoggerFactory>();
            //    // ...
            //}

        }
    }
}
