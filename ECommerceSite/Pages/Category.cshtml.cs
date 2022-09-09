using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;

        public CategoryModel(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public string CategoryName { get; set; }

        public class CategoryViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string CategoryName { get; set; }

            public decimal UnitPrice { get; set; }
        }


        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public void OnGet(int id)
        {
            Categories = _dbContext.Categories.Select(c => new CategoryViewModel
            {
                Id = c.CategoryId,
                Name = c.CategoryName

            }).ToList();

            CategoryName = _dbContext.Categories.First(r => r.CategoryId == id).CategoryName;

            Products = _dbContext.Products
                .Include(e => e.Category)
                .OrderByDescending(t => t.ProductId)
                .Where(r => r.Category.CategoryId == id)
                .Select(r => new ProductViewModel
                {
                    Id = r.ProductId,
                    Name = r.ProductName,
                    CategoryName = r.Category.CategoryName,
                    UnitPrice = r.UnitPrice.Value
                }).ToList();
        }
    }
}
