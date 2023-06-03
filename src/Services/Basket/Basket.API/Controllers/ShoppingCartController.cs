using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Services;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _iMapper;

        public ShoppingCartController(IBasketService basketService, DiscountGrpcService discountGrpcService ,
            IPublishEndpoint publishEndpoint,IMapper mappings)
        {
            _basketService = basketService?? throw new ArgumentNullException(nameof(basketService));
            _discountGrpcService = discountGrpcService?? throw new ArgumentNullException(nameof(discountGrpcService));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _iMapper = mappings;
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

        [Route("[action]", Name = "CheckOut")]
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckOut([FromBody] BasketCheckout basketCheckout)
        {
            var items = await _basketService.GetBasket(basketCheckout.UserName);
            if(items == null)
            {
                return BadRequest();
            }
            var eventMessage = _iMapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = items.TotalPrice;
            await  _publishEndpoint.Publish(eventMessage);
            //await _basketService.DeleteBasket(basketCheckout.UserName);
            return Accepted();
        }
    }
}
