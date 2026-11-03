namespace stok_kontrolü_2.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CriticalLevel { get; set; }
        public Product Product { get; set; }
    }
}