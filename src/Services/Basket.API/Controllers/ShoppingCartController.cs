using Basket.API.Entities;
using Basket.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public ShoppingCartController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        
        [Route("[action]/{username}",Name = "GetBasket")]
        [HttpGet] 
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var item = await _basketService.GetBasket(username);
            return Ok(item?? new ShoppingCart());
        }
         
        [Route("[action]",Name = "AddBasket")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> AddBasket([FromBody] ShoppingCart shoppingCart)
        {
            var item=await _basketService.UpdateBasket(shoppingCart);
            if(item==null)
            {
                return NotFound();
            }
            return Ok(item);
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
