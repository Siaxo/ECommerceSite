using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ECommerceSite.Data
{
    public class DataInitializer
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ECommerceDBContext dBContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dBContext;
            _userManager = userManager;
        }

        public void SeedData()
        {
            _dbContext.Database.Migrate(); //Skapar icke existerande databaser
                                           // add-migration "" för ändringar till databas
            SeedProducts();
            SeedRoles();
            SeedUsers();


            _dbContext.SaveChanges();
            // Seed default user
        }

        private void SeedProducts()
        {
            while (_dbContext.Products.Count() < 100)
            {
                _dbContext.Products.Add(GenerateProduct());
            }
        }

        private void SeedUsers()
        {
            AddUserIfNotExists("test.tester@testing.com", "Hejsan123#", new string[] { "Customer" });
        }

        private void SeedRoles()
        {
            AddRoleIfNotExisting("Customer");
        }

        private void AddRoleIfNotExisting(string roleName)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                _dbContext.Roles.Add(new IdentityRole { Name = roleName, NormalizedName = roleName });
                
            }
        }


        private void AddUserIfNotExists(string userName, string password, string[] roles)
        {
            if (_userManager.FindByEmailAsync(userName).Result != null) return;

            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            _userManager.CreateAsync(user, password).Wait();
            _userManager.AddToRolesAsync(user, roles).Wait();
        }

        private Product GenerateProduct()
        {
            var products = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(e => e.Id, f => 0)
                .RuleFor(e => e.Name, (f, u) => f.Commerce.Product())
                .RuleFor(e => e.Price, (f, u) => Convert.ToDecimal(f.Commerce.Price()))
                .RuleFor(e => e.EanCode, (f, u) => f.Commerce.Ean8())
                .RuleFor(e => e.Category, (f, u) => f.Commerce.Categories(1)[0]);



            var adsGenerator = products.Generate(1).First();
            return adsGenerator;
        }
    }
}
