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
                Id = 100,
                Description = "Новое описание",
                Title = "Новый заголовок",
                Price = 999
            };

            var handler = new EditProductCommandHandler(GetDbContext());
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
                Id = 1,
                Description = "test",
                Title = "test",
                Price = 1
            };

            var handler = new EditProductCommandHandler(GetDbContext());
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}