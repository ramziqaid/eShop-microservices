using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Infrastructure.Core.Web;
using Ordering.Application.Models;
using Ordering.Infrastructure.Core.Mail;

namespace Ordering.Infrastructure.Core
{
    public static class InfrastructureCoreServiceRegistration
    {
        public static IServiceCollection AddInfrastructureCoreServices(this IServiceCollection services, IConfiguration configuration)
        { 

            services.Configure<AppIdentitySettings>(c => configuration.GetSection("AppIdentitySettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<CoreActionFilter>();
            return services;
        }
    }
}
