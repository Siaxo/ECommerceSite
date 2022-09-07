using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Data
{
    public class ECommerceDBContext : IdentityDbContext<IdentityUser>
    {
        public ECommerceDBContext()
        {

        }

        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;initial catalog=ECommerceDB;integrated security=true");
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Categories { get; set; }
    }
}
