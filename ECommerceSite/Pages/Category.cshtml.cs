using ECommerceSite.Models;
using ECommerceSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceSite.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly IPageService _pageService;
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;

        public CategoryModel(ECommerceDBContext dbContext, IPageService pageService, ICartService cartService, ICustomerService customerService)
        {
            _dbContext = dbContext;
            _pageService = pageService;
            _cartService = cartService;
            _customerService = customerService;
        }

        
        public string CategoryName { get; set; }
        public int CurrentPage { get; set; }
        public string Query { get; set; }
        public int PageCount { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        public class CategoryViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class ProductViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string CategoryName { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public int CartId { get; set; }

            public decimal UnitPrice { get; set; }
        }



        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public void OnGet(string query, int id, int pageno = 1)
        {
            //Categories = _dbContext.Categories.Select(c => new CategoryViewModel
            //{
            //    Id = c.CategoryId,
            //    Name = c.CategoryName

            //}).ToList();


            CategoryName = _dbContext.Categories.First(r => r.CategoryId == id).CategoryName;
            CurrentPage = pageno;
            Query = query;

            var pageresult = _pageService.GetPages(CurrentPage, query);

            Products = _dbContext.Products
                .Include(e => e.Category)
                .OrderByDescending(t => t.ProductId)
                .Where(r => r.Category.CategoryId == id)
                .Select(r => new ProductViewModel
                {
                    Id = r.ProductId,
                    Name = r.ProductName,
                    CategoryName = r.Category.CategoryName,
                    UnitPrice = r.UnitPrice.Value
                }).ToList();

            Categories = pageresult.Results.Select(x => new CategoryViewModel
            {
                Id = x.ProductId,
                Name = x.ProductName
            }).ToList();

            PageCount = pageresult.PageCount;

        }


        public IActionResult OnPost(int customerId)
        {
            var customer = _customerService.GetCustomer(customerId);
            var product = new CartItem();
            product.ProductId = ProductId;
            product.Quantity = Quantity;
            product.CartId = CartId;
            var Getcart = _cartService.AddToCart(customer.Id, product.ProductId, product.Quantity);

            return Page();

        }
    }
}
