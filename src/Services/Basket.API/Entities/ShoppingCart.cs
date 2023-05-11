namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string userName { set; get; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }
        public ShoppingCart(string userName)
        {
            this.userName = userName;
        }

        public decimal TotalPrice() => Items.Sum(x => x.Quantity * x.Price);
        //{
        //  return  Items.Sum(x => x.Quantity * x.Price);
        //}
    }
}


