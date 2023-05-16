using System.ComponentModel.DataAnnotations.Schema;

namespace Discount.Grpc.Entities
{
    [Table("coupon2")]
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
    }
}
