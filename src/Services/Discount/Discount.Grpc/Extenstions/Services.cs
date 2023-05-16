

using Dapper;
using Discount.Grpc.Data;
using Discount.Grpc.Services;

namespace Discount.Grpc.Extenstions
{
    public static class Services
    {
        public static void Injections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DiscountDbContext>();
            services.AddScoped<ICouponServices, CouponServices>();
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
