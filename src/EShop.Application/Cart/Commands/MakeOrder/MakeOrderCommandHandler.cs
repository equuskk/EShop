using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Cart.Commands.MakeOrder
{
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public MakeOrderCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var productsInCart = _db.ProductsInCarts.Include(x => x.Product)
                                    .Where(x => x.UserId == request.ShopUserId && x.OrderId == null);

            if(!productsInCart.Any())
            {
                return false;
            }

            var orderSum = 0.0;
            foreach(var item in productsInCart)
            {
                orderSum += item.Product.Price * item.Quantity;
            }

            var order = new Order(orderSum);
            _db.Orders.Add(order);

            await productsInCart.ForEachAsync(x => x.SetOrderId(order.Id),
                                              cancellationToken);

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}