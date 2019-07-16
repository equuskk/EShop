using System.Threading;
using EShop.Application.Categories.Commands.AddCategory;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class AddCategoryTests : TestBase
    {
        [Fact]
        public async void AddCategory_CorrectCategory_ReturnsIdCategory()
        {
            var cmd = new AddCategoryCommand
            {
                Name = "Тест"
            };

            var handler = new AddCategoryCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}