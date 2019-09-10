using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Cart.Queries.GetUserOrder
{
    public class GetUserOrderCommandHandler : IRequestHandler<GetUserOrderCommand, OrderViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetUserOrderCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetUserOrderCommandHandler>();
        }

        public Task<OrderViewModel> Handle(GetUserOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение заказов пользователя {0}", request.UserId);

            var productInCarts = _db.ProductsInCarts.Include(x => x.Order)
                                    .Include(x => x.Product)
                                    .Where(x => x.UserId == request.UserId)
                                    .Where(x => x.OrderId != null)
                                    .ToArray();

            if(productInCarts == null)
            {
                _logger.Debug("У пользователя {0} отсутствуют товары в корзине", request.UserId);
                throw new NotFoundException(nameof(productInCarts), "Не найдено продуктов.");
            }

            _logger.Debug("Заказы пользователя {0} успешно получены", request.UserId);
            return Task.FromResult(new OrderViewModel
            {
                ProductInCarts = productInCarts
            });
        }
    }
}