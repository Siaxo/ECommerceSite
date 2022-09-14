using ECommerceSite.Models;

namespace ECommerceSite.Services
{
    public interface ICartService
    {
        public List<Product> Products { get; set; }
    }
}
