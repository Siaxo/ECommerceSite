namespace ECommerceSite.Models
{
    public class ShopCustomer
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
