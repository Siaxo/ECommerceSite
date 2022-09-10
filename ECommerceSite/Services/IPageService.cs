using ECommerceSite.Infrastructure.Paging;
using ECommerceSite.Models;

namespace ECommerceSite.Services
{
    public interface IPageService
    {
        PagedResult<Product> GetPages(int pageno, string searchQuery);
    }
}
