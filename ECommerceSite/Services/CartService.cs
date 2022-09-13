using ECommerceSite.Infrastructure.Repository;
using ECommerceSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NuGet.Packaging.Core;

namespace ECommerceSite.Services
{
    public class CartService : ICartService
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IStringLocalizer _localizer;

        public CartService(ECommerceDBContext dbContext, IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository,
            IStringLocalizerFactory stringLocalizerFactory)
        {
            _dbContext = dbContext;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _localizer = stringLocalizerFactory.Create(null);
        }

        public IQueryable<Cart> Query()
        {
            return _cartRepository.Query();
        }

        public Task<Cart> GetActiveCart(int customerId)
        {
            return GetActiveCart(customerId, customerId);
        }

        public async Task<Cart> GetActiveCart(int customerId, int cartId)
        {
            return await _cartRepository.Query()
                .Include(x => x.Items)
                .Where(x => x.CustomerId == customerId && x.CartId == cartId && x.IsActive).FirstOrDefaultAsync();
        }

        public async Task<AddToCartResult> AddToCart(int customerId, int productId, int quantity)
        {
            return await AddToCart(customerId, customerId, productId, quantity);
        }

        public async Task<AddToCartResult> AddToCart(int customerId, int cartId, int productId, int quantity)
        {
            var addToCarResult = new AddToCartResult { Success = false };

            if (quantity == 0)
            {
                addToCarResult.ErrorMessage = _localizer["Quantity can't be zero"].Value;
                addToCarResult.ErrorCode = "Choose how many of the product you would like to add to cart";
                return addToCarResult;
            }
            var cart = await GetActiveCart(customerId, cartId);
            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId = customerId,
                    CartId = cartId
                };

                _cartRepository.Add(cart);
            }
            else
            {
                cart = await _cartRepository.Query().Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == cart.Id);
            }

            var cartItem = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Cart = cart,
                    ProductId = productId,
                    Quantity = quantity
                };

                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity = cartItem.Quantity + quantity;
            }

            await _cartItemRepository.SaveChangesAsync();

            addToCarResult.Success = true;
            return addToCarResult;

        }



        
    }
}
