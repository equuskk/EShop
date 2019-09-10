using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Cart.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommandHandler : IRequestHandler<DeleteProductFromCartCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public DeleteProductFromCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<DeleteProductFromCartCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteProductFromCartCommand request, CancellationToken cancellationToken)
        {
            var productInCart =
                    _db.ProductsInCarts.FirstOrDefault(x => x.ProductId == request.ProductId &&
                                                            x.UserId == request.ShopUserId &&
                                                            x.OrderId == null);

            _logger.Debug("Пользователь с ID {request.ProductId} удаляет из корзины продукт с ID {0}",
                          request.ProductId);

            if(productInCart is null)
            {
                throw new NotFoundException(nameof(ProductInCart), request.ProductId);
            }

            if(productInCart.Quantity - request.Quantity <= 0) //TODO: ?
            {
                _db.ProductsInCarts.Remove(productInCart);
            }
            else
            {
                productInCart.SubQuantity(request.Quantity);
            }


            await _db.SaveChangesAsync(cancellationToken);
            _logger.Debug("Пользователь с ID {0} удалил из корзины продукт с ID {1}", request.ShopUserId,
                          request.ProductId);

            return Unit.Value;
        }
    }
}