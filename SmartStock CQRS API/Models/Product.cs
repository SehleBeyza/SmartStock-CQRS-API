namespace stok_kontrolü_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public decimal Price { get; set; }
        public Stock Stock { get; set; }
    }
}