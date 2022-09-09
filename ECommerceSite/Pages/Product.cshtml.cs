using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;

        public ProductModel(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }




        public void OnGet(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == product.CategoryId);

            Id = product.ProductId;
            Name = product.ProductName;
            UnitPrice = product.UnitPrice;
            CategoryId = product.CategoryId;
            CategoryName = category.CategoryName;

            
            




        }
    }
}
