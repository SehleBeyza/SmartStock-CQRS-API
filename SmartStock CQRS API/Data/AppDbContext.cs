using Microsoft.EntityFrameworkCore;
using stok_kontrolü_2.Models;

namespace stok_kontrolü_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
