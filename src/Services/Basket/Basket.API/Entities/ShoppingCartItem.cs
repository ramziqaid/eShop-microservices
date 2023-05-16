namespace Basket.API.Entities
{
    public class ShoppingCartItem
    { 
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }

    }
}
