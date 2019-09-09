using System.Threading;
using EShop.Application.Products.Commands.EditProduct;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class EditProductTests : TestBase
    {
        [Fact]
        public async void EditProduct_CorrectData_ReturnsProduct()
        {
            var cmd = new EditProductCommand(1, "test", 123, "test", 2, 2);
            var handler = new EditProductCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Product>(result);
            Assert.Equal(cmd.ProductId, result.Id);
            Assert.Equal(cmd.Price, result.Price);
            Assert.Equal(cmd.Description, result.Description);
        }

        [Fact]
        public async void EditProduct_IncorrectProductId_ThrowsException()
        {
            var cmd = new EditProductCommand(-1, "test", 123, "test", 2, 2);
            var handler = new EditProductCommandHandler(GetDbContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                                await handler.Handle(cmd, CancellationToken.None));
        }
    }
}