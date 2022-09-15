using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ECommerceDBContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, ECommerceDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

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

        public void OnGet()
        {
            Categories = _dbContext.Categories.Select(c => new CategoryViewModel
            {
                Id = c.CategoryId,
                Name = c.CategoryName

            }).ToList();

            Products = _dbContext.Products.Include(e => e.Category)
                .OrderByDescending(t => t.ProductId)
                .Take(5)
                .Select(r => new ProductViewModel
                {
                    Id = r.ProductId,
                    Name = r.ProductName,
                    CategoryName = r.Category.CategoryName,
                    UnitPrice = r.UnitPrice
                }).ToList();
        }
    }
    
}