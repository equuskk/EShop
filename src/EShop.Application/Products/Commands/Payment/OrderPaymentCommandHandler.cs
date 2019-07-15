using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.Payment
{
    public class OrderPaymentCommandHandler : IRequestHandler<OrderPaymentCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public OrderPaymentCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(OrderPaymentCommand request, CancellationToken cancellationToken)
        {
            var productInCart =  _db.ProductsInCarts.Include(x => x.Product).Where(x => x.ShopUserId == request.ShopUserId && x.OrderId == 0);

            if (productInCart is null)
            {
                return false;
            }

            double OrderSum = 0;
            foreach (var item in productInCart)
            {
                OrderSum += item.Product.Price * item.Quantity;
            }
         
            var order = new Order(OrderSum);
            _db.Orders.Add(order);

            await productInCart.ForEachAsync(x => x.SetOrderId(order.Id));

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
