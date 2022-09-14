namespace ECommerceSite.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }

        public IList<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
