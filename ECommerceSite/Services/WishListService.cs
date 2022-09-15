using ECommerceSite.Models;

namespace ECommerceSite.Services
{
	public class WishListService : IWishListService
	{
        public List<Product> WishList { get; set; } = new List<Product>();
    }
}
