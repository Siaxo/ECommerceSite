using ECommerceSite.Models;

namespace ECommerceSite.Services
{
    public interface ICartService
    {
        Task<AddToCartResult> AddToCart(int customerId, int productId, int quantity);

        Task<AddToCartResult> AddToCart(int customerId, int cartId, int productId, int quantity);

        IQueryable<Cart> Query();

        Task<Cart> GetActiveCart(int customerId);

        Task<Cart> GetActiveCart(int customerId, int cartId);


    }
}
