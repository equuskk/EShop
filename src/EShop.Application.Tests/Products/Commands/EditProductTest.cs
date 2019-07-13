using EShop.Application.Products.Commands.EditProduct;
using EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class EditProductTest : TestBase
    {
        [Fact]
        public async void EditProduct_CorrectEditProduct_ReturnsProduct()
        {
            var cmd = new EditProductCommand
            {
                Id = 100,
                Description = "Новое описание",
                Title = "Новый заголовок",
                Price = 999
            };

            var handler = new EditProductCommandHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Product>(result);
            Assert.True(cmd.Id == result.Id);
            Assert.True(cmd.Price == result.Price);
            Assert.True(cmd.Description == result.Description);
        }
    }
}
