using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _client;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<CouponModel> GetDiscount(string productId)
        {
            var discount = new GetDiscountRequest { ProductId = productId };
            return await _client.GetDiscountAsync(discount);
        }
    }
}
