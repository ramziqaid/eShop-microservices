using Basket.API.GrpcServices;
using Basket.API.Services;
using Discount.Grpc.Protos;

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

            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(o =>
            {
                o.Address = new Uri(configuration.GetValue<string>("GrpcSettings:DiscountUrl"));
            });
            services.AddScoped<DiscountGrpcService>();
        }
    }
}
