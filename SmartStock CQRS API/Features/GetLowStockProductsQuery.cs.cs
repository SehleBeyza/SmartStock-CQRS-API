using MediatR;
using Microsoft.EntityFrameworkCore;
using stok_kontrolü_2.Data;

namespace stok_kontrolü_2.Features.Queries
{
    public class GetLowStockProductsQuery : IRequest<List<ProductDto>>
    {
        public int Threshold { get; set; } = 10; 
    }

    public class GetLowStockProductsQueryHandler : IRequestHandler<GetLowStockProductsQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;

        public GetLowStockProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetLowStockProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.Stock)
                .Where(p => p.Stock != null && p.Stock.Quantity <= request.Threshold)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.Stock.Quantity
                })
                .ToListAsync(cancellationToken);
        }
    }
}