using ECommerceSite.Infrastructure.Repository;

namespace ECommerceSite.Models
{
    public class Cart : EntityBase
    {
        public int CustomerId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }


        public IList<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
