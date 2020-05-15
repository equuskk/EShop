using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Serilog;

namespace EShop.Application.Cart.Commands.AddProductToCart
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public AddProductToCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<AddProductToCartCommandHandler>();
        }

        public async Task<Unit> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Пользователь {0} добавляет продукт {1} в корзину", request.ShopUserId,
                          request.ProductId);


            var productInCart = new ProductInCart(request.ShopUserId, request.ProductId, request.Quantity);

            _db.ProductsInCarts.Add(productInCart);

            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Пользователь {0} добавил продукт {1} в корзину", request.ShopUserId,
                          request.ProductId);

            return Unit.Value;
        }
    }
}