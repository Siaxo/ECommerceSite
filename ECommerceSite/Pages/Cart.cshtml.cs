using Bogus.DataSets;
using ECommerceSite.Models;
using ECommerceSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ECommerceSite.Pages
{
    [BindProperties]
    public class CartModel : PageModel
    {
        private readonly ICartService _cartService;
        private readonly ECommerceDBContext _dBContext;

        public CartModel(ICartService cartService, ECommerceDBContext dBContext)
        {
            _cartService = cartService;
            _dBContext = dBContext;
        }
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        [EmailAddress(ErrorMessage ="Please enter a valid email adress")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
 
        public void OnGet()
        {
            TotalPrice = _cartService.Products.Sum(t => t.UnitPrice);
        }

        public IActionResult OnPost()
        {
            var customer = new ShopCustomer();
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.Country = Country;
            customer.ZipCode = ZipCode;
            customer.PhoneNumber = PhoneNumber;
            customer.Email = Email;
            customer.Address = Address;
            customer.City = City;
            customer.Id = CustomerId;

            return RedirectToAction("Confirmation");
        }
    }
}
