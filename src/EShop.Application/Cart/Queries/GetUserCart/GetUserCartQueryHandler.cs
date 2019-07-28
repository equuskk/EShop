using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Cart.Queries.GetUserCart
{
    public class GetUserCartQueryHandler : IRequestHandler<GetUserCartQuery, CartViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetUserCartQueryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<CartViewModel> Handle(GetUserCartQuery request, CancellationToken cancellationToken)
        {
            var cart = _db.ProductsInCarts.Where(x => x.UserId == request.ShopUserId &&
                                                      x.OrderId == null).Select(x => x.ProductId);
            var products = _db.Products.Where(x => cart.Contains(x.Id)); //TODO:

            return Task.FromResult(new CartViewModel
            {
                Products = products.ToArray()
            });
        }
    }
}