using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly DiscountGrpcService _discountGrpcService;

        public ShoppingCartController(IBasketService basketService, DiscountGrpcService discountGrpcService )
        {
            _basketService = basketService?? throw new ArgumentNullException(nameof(basketService));
            _discountGrpcService = discountGrpcService?? throw new ArgumentNullException(nameof(discountGrpcService));
        }
        
        [Route("[action]/{username}",Name = "GetBasket")]
        [HttpGet] 
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        { 
            var item = await _basketService.GetBasket(username);
            return Ok(item?? new ShoppingCart(username));
        }
         
        [Route("[action]",Name = "AddBasket")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> AddBasket([FromBody] ShoppingCart shoppingCart)
        {
            //TODO :comunicate with discount Grpc 
            foreach (var item in shoppingCart.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                if(coupon != null)
                {
                    item.Price =Convert.ToDecimal( coupon.Amount);
                }
            }
            var cart=await _basketService.UpdateBasket(shoppingCart);
            if(cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }


        // DELETE api/<ShoppingCartController>/5
        [Route("[action]/{username}", Name = "DeleteBasket")]
        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            await _basketService.DeleteBasket(username);
            return Ok();
        }
    }
}
