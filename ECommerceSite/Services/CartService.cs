using ECommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Services
{
    public class CartService : ICartService
    {
        //private readonly ECommerceDBContext _dbContext;

        //public CartService(ECommerceDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
