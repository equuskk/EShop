using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var cart = _db.ProductsInCarts.Include(x => x.Product).Where(x => x.UserId == request.ShopUserId &&
                                                      x.OrderId == null).Select(x => x.Product);
           

            return Task.FromResult(new CartViewModel
            {
                Products = cart.ToArray()
            });
        }
    }
}