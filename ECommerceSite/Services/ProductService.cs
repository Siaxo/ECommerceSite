using ECommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services
{
    public class ProductService : IProductService
    {
        private readonly ECommerceDBContext _dBContext;

        public ProductService(ECommerceDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public IEnumerable<Product> GetAll()
        {
            return _dBContext.Products.Include(product => product.Category);
        }

        public Product GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ProductId == id);
        }
    }
}
