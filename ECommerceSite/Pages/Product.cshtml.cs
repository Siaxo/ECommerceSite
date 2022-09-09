using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;

        public ProductModel(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }




        public void OnGet(int id)
        {
            var product = _dbContext.Products.First(x => x.ProductId == id);

            Id = product.ProductId;
            Name = product.ProductName;
            UnitPrice = product.UnitPrice;
            

        }
    }
}
