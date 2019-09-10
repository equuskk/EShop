using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetProductByIdQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetProductByIdQueryHandler>();
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение продукта с ID = {0}", request.ProductId);
            var product = await _db.Products.Include(x => x.Vendor).Include(x => x.Category)
                                   .SingleOrDefaultAsync(x => x.Id == request.ProductId,
                                                         cancellationToken);
            if(product is null)
            {
                _logger.Debug("Продукт c ID = {0} не найден", request.ProductId);
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            return product;
        }
    }
}