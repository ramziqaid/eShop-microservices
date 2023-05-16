using Dapper;
using Discount.API.Data;
using Discount.API.Entities;
using Npgsql;
using System.Xml.Linq;

namespace Discount.API.Services
{
    public class CouponServices : ICouponServices
    {
        private DiscountDbContext _discountDbContext;
        private readonly IConfiguration _configuration;
        public CouponServices(DiscountDbContext discountDbContext, IConfiguration configuration)
        {
            _discountDbContext = discountDbContext;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
      

        public async Task<Coupon> GetDiscount(string productId)
        {
            //using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            //var coupon22 = await connection.QueryFirstOrDefaultAsync<Coupon>
            //    ("SELECT * FROM coupon2 ");

            //if (coupon == null)
            //    return new Coupon { ProductName = "No Discount", Amount = 0 };
            //return coupon;

            Coupon coupon = null;
            using (var conn = _discountDbContext.CreateConnection())
            {
                var result = conn.GetList<Coupon>(new { ProductId = productId });
                coupon = result.FirstOrDefault();

                //var coupon2 = await conn.QueryFirstOrDefaultAsync<Coupon>
                //    ("SELECT * FROM Coupon WHERE productId = @productId", new { productId = productId });

                //var sql = "SELECT * FROM coupon";
                //var resilt = conn.QueryFirstOrDefault<Coupon>(sql);
            }

            return coupon;
        }

        public async Task<bool> CreateAsync(Coupon coupon)
        {
            using (var conn = _discountDbContext.CreateConnection())
            {
                var result = await conn.InsertAsync(coupon);
                if (result == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<Coupon> UpdateAsync(Coupon coupon)
        {
            using (var conn = _discountDbContext.CreateConnection())
            {
                var result = await conn.UpdateAsync(coupon);
                if (result == 0)
                {
                    throw new Exception("Not Update");
                }
            }
            return coupon;
        }
        public async Task<bool> DeleteDiscount(int id)
        {
            using (var conn = _discountDbContext.CreateConnection())
            {
                var coupon = await  conn.GetAsync<Coupon>(id);
                ArgumentNullException.ThrowIfNull(coupon);

                var result = await conn.DeleteAsync(coupon);
                if(result == 0)
                {
                    return false;
                } 
            }
            return true;
        }



    }
}
