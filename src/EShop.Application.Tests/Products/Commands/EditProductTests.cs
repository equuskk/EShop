using System.Threading;
using EShop.Application.Products.Commands.EditProduct;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class EditProductTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public EditProductTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void EditProduct_CorrectData_ReturnsProduct()
        {
            var cmd = new EditProductCommand
            {
                Id = 1,
                Description = "Новое описание",
                Title = "Новый заголовок",
                Price = 999,
                VendorId = 2,
                CategoryId = 2
            };

            var handler = new EditProductCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Product>(result);
            Assert.Equal(cmd.Id, result.Id);
            Assert.Equal(cmd.Price, result.Price);
            Assert.Equal(cmd.Description, result.Description);
        }

        [Fact]
        public async void EditProduct_IncorrectData_ThrowsException()
        {
            var cmd = new EditProductCommand
            {
                Id = -1,
                Description = "test",
                Title = "test",
                Price = 1,
                VendorId = 0,
                CategoryId = 0
            };

            var handler = new EditProductCommandHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}