using ECommerceSite.Infrastructure.Paging;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Authentication;

namespace ECommerceSite.Services
{
    public class PageService : IPageService
    {
        private readonly ECommerceDBContext _dbContext;

        public PageService(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PagedResult<Product> GetPages(int pageno, string searchQuery)
        {
            var query = _dbContext.Products.Where(s => searchQuery == null || (s.ProductName.Contains(searchQuery))).GetPaged(pageno, 50);

            return query;

        }
    }
}
