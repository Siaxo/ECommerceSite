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
    }
}
