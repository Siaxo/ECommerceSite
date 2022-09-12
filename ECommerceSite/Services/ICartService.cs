using ECommerceSite.Models;

namespace ECommerceSite.Services
{
    public interface ICartService
    {
        public void Update(Cart cart);
        public Cart GetCart(int cartId);
    }
}
