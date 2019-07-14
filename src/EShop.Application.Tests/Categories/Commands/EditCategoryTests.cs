using System.Threading;
using EShop.Application.Categories.Commands.EditCategory;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class EditCategoryTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public EditCategoryTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void EditCategory_CorrectData_ReturnsCategory()
        {
            var cmd = new EditCategoryCommand
            {
                Id = 1,
                Name = "New Name"
            };

            var handler = new EditCategoryCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Category>(result);
            Assert.Equal(cmd.Id, result.Id);
            Assert.Equal(cmd.Name, result.Name);
        }

        [Fact]
        public async void EditCategory_IncorrectData_ThrowsException()
        {
            var cmd = new EditCategoryCommand
            {
                Id = -1,
                Name = "Test"
            };

            var handler = new EditCategoryCommandHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
