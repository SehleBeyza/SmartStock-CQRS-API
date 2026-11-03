using stok_kontrolü_2.Data;

namespace stok_kontrolü_2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IStockRepository Stocks { get; }

        public UnitOfWork(AppDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            Stocks = stockRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
