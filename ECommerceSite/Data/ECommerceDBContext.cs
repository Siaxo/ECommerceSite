using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Data
{
    public class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext()
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
