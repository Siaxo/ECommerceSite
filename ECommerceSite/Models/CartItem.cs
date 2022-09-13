using ECommerceSite.Infrastructure.Repository;

namespace ECommerceSite.Models
{
	public class CartItem : EntityBase
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public int CartId { get; set; }
		public Cart Cart { get; set; }
	}
}
