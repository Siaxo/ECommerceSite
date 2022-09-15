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
        private readonly IWishListService _wishListService;

        public CategoryModel(ECommerceDBContext dbContext, IPageService pageService, ICartService cartService, IWishListService wishListService)
        {
            _dbContext = dbContext;
            _pageService = pageService;
            _cartService = cartService;
            _wishListService = wishListService;
        }

        
        public string CategoryName { get; set; }
        public int CurrentPage { get; set; }
        public string Query { get; set; }
        public int PageCount { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public int CategoryId { get; set; }


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
            Quantity = 1;
            CategoryId = id;

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
                    UnitPrice = r.UnitPrice
                }).ToList();

            Categories = pageresult.Results.Select(x => new CategoryViewModel
            {
                Id = x.ProductId,
                Name = x.ProductName
            }).ToList();

            PageCount = pageresult.PageCount;

        }


        public IActionResult OnPost(int productId, int categoryId)
        {
           var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);

            _cartService.Products.Add(product);

            return RedirectToPage(new {Id = categoryId});

            
        }

        //public IActionResult OnPost2(int productId2, int categoryId2)
        //{
        //    var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId2);

        //    _wishListService.WishList.Add(product);

        //    return RedirectToPage(new { Id = categoryId2 });


        //}
    }
}
