using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ProductsDbContext _db;

        public GetProductByIdQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.Include(x => x.Vendor).Include(x => x.Category)
                                   .SingleOrDefaultAsync(x => x.Id == request.ProductId,
                                                         cancellationToken);
            if(product is null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            return product;
        }
    }
}