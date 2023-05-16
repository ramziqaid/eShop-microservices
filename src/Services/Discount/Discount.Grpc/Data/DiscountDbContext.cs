using Npgsql;

namespace Discount.Grpc.Data
{
    public class DiscountDbContext
    {
        protected readonly IConfiguration Configuration;
        public NpgsqlConnection connection;

        public DiscountDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            CreateConnection();
        }
        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to postgres with connection string from app settings
        //    options.UseNpgsql(Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
           
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.HasDefaultSchema("public");
        //    //base.OnModelCreating(modelBuilder);
        //}

        //public DbSet<Coupon> Coupons { get; set; }
      
    }
}
