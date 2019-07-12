using EShop.Application.Products.Commands.CreateNewProduct;
using EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class CreateNewProductTest : TestBase
    {
        [Fact]
        public async void CreateNewProduct_CorrectProduct_ReturnsProduct()
        {
            var cmd = new CreateNewProductCommand
            {
                Id = 3,
                Description ="Моё описание",
                Title = "Мой заголовок",
                Price = 12
            };

            var handler = new CreateNewProductHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(cmd.Price, result.Price);
            Assert.Equal(cmd.Title, result.Title);
        }
    }
}
