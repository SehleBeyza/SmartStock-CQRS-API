using stok_kontrolü_2.Models;

namespace stok_kontrolü_2.Repositories
{
    public interface IStockRepository
    {
        Task<Stock> GetByProductIdAsync(int productId);
        Task AddAsync(Stock stock);
    }
}