using MassTransit;
using RabbitMQ.Client;

namespace Basket.API.Extenstions
{
    public static class RabbitMQService
    {
        public static IServiceCollection AddRabbitMQServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ct, d) => {
                    d.Host(configuration.GetValue<string>("RabbitMQ:url"));
                    d.ExchangeType = ExchangeType.Direct;
                    
                });
            });
            //services.AddMassTransitHostedService();
            return services;
        }
    }
}
