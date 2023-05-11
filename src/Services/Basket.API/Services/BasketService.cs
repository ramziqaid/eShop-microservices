using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _cache;

        public BasketService(IDistributedCache cache)
        {
            _cache = cache;
        }
 
        public async Task<ShoppingCart> GetBasket(string pUserName)
        {
            var basket =await _cache.GetStringAsync(pUserName);
            if (basket == null) return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }
       
        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        { 
            await _cache.SetStringAsync(shoppingCart.userName,JsonConvert.SerializeObject(shoppingCart));
            return await GetBasket(shoppingCart.userName);
        }
       

        public async Task DeleteBasket(string pUserName)
        {
            await _cache.RemoveAsync(pUserName); 
        }

       
    }
}
