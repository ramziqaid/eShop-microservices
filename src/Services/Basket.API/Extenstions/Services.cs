using Basket.API.Services;

namespace Basket.API.Extenstions
{
    public static class Services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBasketService, BasketService>();
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });
        }
    }
}
