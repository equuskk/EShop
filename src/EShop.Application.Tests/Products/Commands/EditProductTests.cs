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
            var cmd = new EditProductCommand
            {
                ProductId = 1,
                Description = "test",
                Title = "test",
                Price = 123,
                VendorId = 2,
                CategoryId = 2
            };
            var handler = new EditProductCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Product>(result);
            Assert.Equal(cmd.ProductId, result.Id);
            Assert.Equal(cmd.Price, result.Price);
            Assert.Equal(cmd.Description, result.Description);
        }

        [Fact]
        public async void EditProduct_IncorrectProductId_ThrowsException()
        {
            var cmd = new EditProductCommand
            {
                ProductId = -1,
                Description = "test",
                Title = "test",
                Price = 1,
                VendorId = 1,
                CategoryId = 1
            };
            var handler = new EditProductCommandHandler(GetProductsContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                                await handler.Handle(cmd, CancellationToken.None));
        }
    }
}