﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Cart.Commands.MakeOrder
{
    public class MakeOrderCommandHandler : IRequestHandler<MakeOrderCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public MakeOrderCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<MakeOrderCommandHandler>();
        }

        public async Task<bool> Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            var productsInCart = _db.ProductsInCarts.Include(x => x.Product)
                                    .Where(x => x.UserId == request.ShopUserId && x.OrderId == null);

            _logger.Debug("Добавление заказа для пользователя с ID {0}", request.ShopUserId);

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
            await _db.SaveChangesAsync(cancellationToken); // для того, чтобы получить ID заказа

            await productsInCart.ForEachAsync(x => x.SetOrderId(order.Id),
                                              cancellationToken);

            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}