using Discount.API.Entities;
using Discount.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private   ICouponServices _couponServices { get; set; }

        // GET: api/<CouponController>
        public CouponController(ICouponServices couponServices)
        {
            _couponServices=couponServices;
        }

        [Route("[action]/{productId}", Name = "GetCoupon")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof (IEnumerable<Coupon>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetCoupon(string productId)
        {
            var result = await _couponServices.GetDiscount(productId);
            //_logger.LogInformation("get Product");
            return Ok(result);
        }
         
        [Route("[action]", Name = "CreateCoupon")]
        [HttpPost] 
        [ProducesResponseType(typeof (bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> CreateCoupon([FromBody]  Coupon coupon)
        {
            var result = await _couponServices.CreateAsync(coupon);
            //_logger.LogInformation("get Product");
            return Ok(result);
        }

        [Route("[action]", Name = "UpdateCoupon")]
        [HttpPut] 
        [ProducesResponseType(typeof (Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateCoupon([FromBody]  Coupon coupon)
        {
            var result = await _couponServices.UpdateAsync(coupon);
            //_logger.LogInformation("get Product");
            return Ok(result);
        }
           
        [Route("[action]/{id}", Name = "DeleteCoupon")]
        [HttpDelete] 
        [ProducesResponseType(typeof (bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteCoupon(int id)
        {
            var result = await _couponServices.DeleteDiscount(id);
            //_logger.LogInformation("get Product");
            return Ok(result);
        }
         

     

     
    }
}
