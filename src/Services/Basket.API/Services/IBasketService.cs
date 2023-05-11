using Basket.API.Entities;

namespace Basket.API.Services
{
    public interface IBasketService
    {
        Task<ShoppingCart> GetBasket(string pUserName);
       // Task<ShoppingCart> CreateBasket(ShoppingCart shoppingCart);
        Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string pUserName);
    }
}
