namespace stok_kontrolü_2.Repositories
{
    public interface IUnitOfWork
    {
        IStockRepository Stocks { get; }
        Task<int> CompleteAsync();
    }
}