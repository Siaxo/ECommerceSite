namespace ECommerceSite.Models
{
    public class Cart
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
