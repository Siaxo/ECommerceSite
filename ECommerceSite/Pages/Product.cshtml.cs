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

        public ProductModel(ECommerceDBContext dbContext, ICartService cartService)
        {
            _dbContext = dbContext;
            _cartService = cartService;
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

        public IActionResult OnPost(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);

            _cartService.ShoppingCart.Add(product);

            return RedirectToPage(new { Id = productId });


        }
    }
}
