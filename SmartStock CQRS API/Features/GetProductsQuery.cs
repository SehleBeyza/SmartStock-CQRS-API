using MediatR;
using Microsoft.EntityFrameworkCore;
using stok_kontrolü_2.Data;

namespace stok_kontrolü_2.Features.Queries
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    public class GetProductsQuery : IRequest<List<ProductDto>> { }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly AppDbContext _context;

        public GetProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.Stock)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockQuantity = p.Stock != null ? p.Stock.Quantity : 0
                })
                .ToListAsync(cancellationToken);
        }
    }
}