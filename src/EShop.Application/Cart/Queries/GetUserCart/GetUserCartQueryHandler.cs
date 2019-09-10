using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Cart.Queries.GetUserCart
{
    public class GetUserCartQueryHandler : IRequestHandler<GetUserCartQuery, CartViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetUserCartQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetUserCartQueryHandler>();
        }

        public Task<CartViewModel> Handle(GetUserCartQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение корзины пользователя {0}", request.ShopUserId);

            var cart = _db.ProductsInCarts.Include(x => x.Product)
                          .Where(x => x.UserId == request.ShopUserId && x.OrderId == null)
                          .Select(x => x.Product);
            
            return Task.FromResult(new CartViewModel
            {
                Products = cart.ToArray()
            });
        }
    }
}