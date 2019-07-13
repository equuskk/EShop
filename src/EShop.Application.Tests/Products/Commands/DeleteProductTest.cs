using EShop.Application.Products.Commands.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class DeleteProductTest : TestBase
    {

        [Fact]

        public async void DeleteProduct_CorrectDeleteProduct_ReturnsBool()
        {
            var cmd = new DeleteProductCommand
            {
                Id = 100,
            };

            var handler = new DeleteProductCommandHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

    }
}
