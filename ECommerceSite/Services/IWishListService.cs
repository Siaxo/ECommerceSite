using ECommerceSite.Models;

namespace ECommerceSite.Services
{
	public interface IWishListService
	{
        public List<Product> WishList { get; set; }
    }
}
