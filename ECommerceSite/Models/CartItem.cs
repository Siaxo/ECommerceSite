using ECommerceSite.Infrastructure.Repository;

namespace ECommerceSite.Models
{
    public class CartItem
    {
		public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
