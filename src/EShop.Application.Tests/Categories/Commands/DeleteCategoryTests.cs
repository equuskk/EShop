using System.Threading;
using EShop.Application.Categories.Commands.DeleteCategory;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class DeleteCategoryTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public DeleteCategoryTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void DeleteCategory_CorrectData_ReturnsTrue()
        {
            var cmd = new DeleteCategoryCommand
            {
                Id = 1
            };

            var handler = new DeleteCategoryCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteCategory_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteCategoryCommand
            {
                Id = -1
            };

            var handler = new DeleteCategoryCommandHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
