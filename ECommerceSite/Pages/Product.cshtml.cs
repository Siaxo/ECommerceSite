using ECommerceSite.Models;
using ECommerceSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly ICartService _cartService;
        private readonly IWishListService _wishListService;

        public ProductModel(ECommerceDBContext dbContext, ICartService cartService, IWishListService wishListService)
        {
            _dbContext = dbContext;
            _cartService = cartService;
            _wishListService = wishListService;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }




        public void OnGet(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);

            Id = product.ProductId;
            Name = product.ProductName;
            UnitPrice = product.UnitPrice;
            CategoryId = product.CategoryId;
            CategoryName = category.CategoryName;
            Quantity = 1;

        }

        public IActionResult OnPostAddToCart(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);

            _cartService.ShoppingCart.Add(product);

            return RedirectToPage(new { Id = productId });


        }

        public IActionResult OnPostAddToWishList(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);

            _wishListService.WishList.Add(product);

            return RedirectToPage(new { Id = productId });
        }
    }
}
