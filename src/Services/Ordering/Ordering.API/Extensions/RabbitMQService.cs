using EventBus.Messages.Events;
using MassTransit;
using Ordering.API.EventBusConsumer;
using System.Reflection;

namespace Ordering.API.Extenstions
{
    public static class RabbitMQService
    {
        public static IServiceCollection AddRabbitMQServices(this IServiceCollection services, IConfiguration configuration)
        {
           var Host = configuration.GetValue<string>("AppIdentitySettings:RabbitMQ:url");
            var Queue1 = configuration.GetValue<string>("AppIdentitySettings:RabbitMQ:BasketCheckOutQueue");
            services.AddMassTransit(x =>
            {
             
                x.AddConsumers(typeof(BasketCheckOutConsumer).Assembly);
                // x.AddConsumer<BasketCheckOutConsumer>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(Host);

                    cfg.ReceiveEndpoint(Queue1, ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<BasketCheckOutConsumer>(provider);
                    });
                }));
            });
            //services.AddMassTransit(config =>
            //{
            //    config.UsingRabbitMq((ct, d) => {
            //        d.Host(Host);
            //    });
            //});
            //services.AddMassTransit(config =>
            //{
            //    config.AddConsumer<BasketCheckOutConsumer>();
            //    config.UsingRabbitMq((ct, d) =>
            //    {
            //        d.Host(Host);

            //        d.ReceiveEndpoint(Queue1,
            //            r =>
            //            {
            //                r.ConfigureConsumer<BasketCheckOutConsumer>(ct);
            //            });
            //    });

            //});
            //services.AddScoped<BasketCheckOutConsumer>();
            //services.AddMassTransitHostedService();
            return services;
        }
    }
}
