using System.Threading;
using EShop.Application.Categories.Commands.AddCategory;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class AddCategoryTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public AddCategoryTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void AddCategory_CorrectCategory_ReturnsIdCategory()
        {
            var cmd = new AddCategoryCommand
            {
                Name = "Тест"
            };

            var handler = new AddCategoryCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}