using ECommerceSite.Models;
using Microsoft.AspNetCore.Authentication;

namespace ECommerceSite.Services
{
    public class SearchService : ISearchService
    {
        private readonly ECommerceDBContext _dbContext;

        public SearchService(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product SearchProduct(string searchQuery)
        {
            var query = _dbContext.Products.FirstOrDefault(s => searchQuery == null || (s.ProductName == searchQuery));

            return query;
        }
    }
}
