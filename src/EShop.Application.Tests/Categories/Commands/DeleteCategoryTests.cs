using System.Threading;
using EShop.Application.Categories.Commands.DeleteCategory;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class DeleteCategoryTests : TestBase
    {
        [Fact]
        public async void DeleteCategory_CorrectId_ReturnsTrue()
        {
            var cmd = new DeleteCategoryCommand
            {
                CategoryId = 1
            };

            var handler = new DeleteCategoryCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteCategory_IncorrectId_ThrowsException()
        {
            var cmd = new DeleteCategoryCommand
            {
                CategoryId = -1
            };

            var handler = new DeleteCategoryCommandHandler(GetProductsContext());
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}