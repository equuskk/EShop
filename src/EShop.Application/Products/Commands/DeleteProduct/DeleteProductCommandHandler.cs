using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public DeleteProductCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id,
                                                                 cancellationToken);

            if(product is null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}