namespace ECommerceSite.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string EanCode { get; set; }
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
