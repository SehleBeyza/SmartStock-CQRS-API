using MediatR;
using stok_kontrolü_2.Repositories;

namespace stok_kontrolü_2.Features.Commands
{
    public class IncreaseStockCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class IncreaseStockCommandHandler : IRequestHandler<IncreaseStockCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IncreaseStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(IncreaseStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _unitOfWork.Stocks.GetByProductIdAsync(request.ProductId);
            if (stock == null) return false;

            stock.Quantity += request.Quantity;
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}