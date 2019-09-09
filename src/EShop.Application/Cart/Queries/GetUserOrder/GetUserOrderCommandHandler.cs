using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Cart.Queries.GetUserOrder
{
    public class GetUserOrderCommandHandler : IRequestHandler<GetUserOrderCommand, OrderViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetUserOrderCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<OrderViewModel> Handle(GetUserOrderCommand request, CancellationToken cancellationToken)
        {
            var productInCarts = _db.ProductsInCarts.Include(x => x.Order)
                                    .Include(x => x.Product)
                                    .Where(x => x.UserId == request.UserId)
                                    .Where(x => x.OrderId != null)
                                    .ToArray();

            if(productInCarts == null)
            {
                throw new NotFoundException(nameof(productInCarts), "Не найдено продуктов.");
            }

            return Task.FromResult(new OrderViewModel
            {
                ProductInCarts = productInCarts
            });
        }
    }
}