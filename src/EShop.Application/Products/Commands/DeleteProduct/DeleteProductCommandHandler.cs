using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public DeleteProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(request.ProductId);

            if(product is null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}