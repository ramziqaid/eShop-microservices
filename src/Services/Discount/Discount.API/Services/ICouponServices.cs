using Discount.API.Entities;

namespace Discount.API.Services
{
    public interface ICouponServices
    {
        Task<bool> CreateAsync(Coupon coupon);
        Task<Coupon> UpdateAsync(Coupon coupon);
        Task<Coupon> GetDiscount(string productId);

        Task<bool> DeleteDiscount(int id);
    }
}
