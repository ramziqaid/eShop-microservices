using AutoMapper;
using Dapper;
using Discount.API.Services;
using Discount.Grpc.Data;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountServices : DiscountProtoService.DiscountProtoServiceBase
    { 
        private readonly ICouponServices _couponServices;
        private readonly ILogger<DiscountServices> _logger;
        private readonly IMapper _mapper;

        public DiscountServices(ICouponServices couponServices, ILogger<DiscountServices> logger, IMapper mapper)
        {
            _couponServices = couponServices; 
            _logger = logger?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon =await _couponServices.GetDiscount(request.ProductId);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product not has discount {request.ProductId}"));
            }
            _logger.LogInformation($"Success Product  has discount {request.ProductId}");
            var model=_mapper.Map<CouponModel>(coupon);
            return model;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = _mapper.Map<Coupon>(request.Coupon);
            var result = await _couponServices.CreateAsync(coupon);
            if (result == false)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product not CreateDiscount {request.Coupon.ProductId}"));
            }
            _logger.LogInformation($"Success Product  CreateDiscount {request.Coupon.ProductId}");
            var model = _mapper.Map<CouponModel>(coupon);
            return model;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            Coupon coupon = _mapper.Map<Coupon>(request.Coupon);
            var result = await _couponServices.UpdateAsync(coupon);
            if (result == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product not UpdateDiscount {request.Coupon.ProductId}"));
            }
            _logger.LogInformation($"Success Product  UpdateDiscount {request.Coupon.ProductId}");
            var model = _mapper.Map<CouponModel>(coupon);
            return model;
        }

        public override async Task<DeleteDiscountresponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var result = await _couponServices.DeleteDiscount(request.ProductId);
            var response = new DeleteDiscountresponse { Success = result };
            return response;

        }
    }
}
