using ECommerceSite.Models;

namespace ECommerceSite.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
    }
}
