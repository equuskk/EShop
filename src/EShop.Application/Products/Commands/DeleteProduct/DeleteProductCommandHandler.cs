using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public DeleteProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<DeleteProductCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FindAsync(request.ProductId);

            _logger.Debug("Удаление продукта {0}", request.ProductId);

            if(product is null)
            {
                _logger.Debug("Продукт {0} не найден", request.ProductId);
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Продукт {0} удалён", request.ProductId);

            return Unit.Value;
        }
    }
}