﻿using EShop.Application.Products.Commands.AddProductInCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class AddProductInCartTest : TestBase
    {
        [Fact]
        public async void AddProductInCart_CorrectAddProduct_ReturnsIdProductInCart()
        {
            var cmd = new AddProductInCartCommand
            {
                ProductId = ProductsContext.Products.First().Id,
                Quantity = 2,
                ShopUserId = UserId,

            };

            var handler = new AddProductInCartCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
    }
}
