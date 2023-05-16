using Discount.Grpc.Entities;

namespace Discount.Grpc.Services
{
    public interface ICouponServices
    {
        Task<bool> CreateAsync(Coupon coupon);
        Task<Coupon> UpdateAsync(Coupon coupon);
        Task<Coupon> GetDiscount(string productId);

        Task<bool> DeleteDiscount(string productId);
    }
}
