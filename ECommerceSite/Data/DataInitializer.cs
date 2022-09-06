using Bogus;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Data
{
    public class DataInitializer
    {
        private readonly ECommerceDBContext _dbContext;

        public DataInitializer(ECommerceDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public void SeedData()
        {
            _dbContext.Database.Migrate(); //Skapar icke existerande databaser
                                           // add-migration "" för ändringar till databas


            _dbContext.SaveChanges();
            // Seed default user
        }

        private Product GenerateAd()
        {
            var products = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(e => e.Id, f => 0)
                .RuleFor(e => e.Name, (f, u) => f.Commerce.Product())
                .RuleFor(e => e.Price, (f, u) => Convert.ToDecimal(f.Commerce.Price()))
                .RuleFor(e => e.EanCode, (f, u) => f.Commerce.Ean8())
                .RuleFor(e => e.Category, (f, u) => f.Commerce.Categories());



            var adsGenerator = ads.Generate(1).First();
            return adsGenerator;
        }
    }
}
