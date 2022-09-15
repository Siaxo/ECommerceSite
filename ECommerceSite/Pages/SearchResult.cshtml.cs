using ECommerceSite.Models;
using ECommerceSite.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Pages
{
    public class SearchResultModel : PageModel
    {

        private readonly ECommerceDBContext _dbContext;
        private readonly ISearchService _searchServiceService;

        public SearchResultModel(ECommerceDBContext dbContext, ISearchService searchService)
        {
            _dbContext = dbContext;
            _searchServiceService = searchService;
        }

        public class ProductViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string CategoryName { get; set; }

            public decimal UnitPrice { get; set; }
        }

        public List<ProductViewModel> Products { get; set; }

        public void OnGet(string searchQuery)
        {
            var searchResult = _searchServiceService.SearchProduct(searchQuery);

            Products = _dbContext.Products
                .Include(e => e.Category)
                .OrderByDescending(t => t.ProductId)
                .Where(r => r.Category.CategoryName == searchQuery)
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
