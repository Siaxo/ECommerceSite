using ECommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services
{
    public class CartService : ICartService
    {
        private readonly ECommerceDBContext _dbContext;

        public CartService(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Cart cart)
        {
            _dbContext.SaveChanges();
        }

        public Cart GetCart(int id)
        {
            return _dbContext.Carts.Include(c => c.CartItemId).First(e => e.CartId == id);
        }
    }
}
