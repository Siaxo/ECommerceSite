using ECommerceSite.Models;

namespace ECommerceSite.Services
{
    public interface ISearchService
    {
        public Product SearchProduct(string searchQuery);
    }
}
