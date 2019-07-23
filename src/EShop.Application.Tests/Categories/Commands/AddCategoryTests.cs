using System.Threading;
using EShop.Application.Categories.Commands.AddCategory;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class AddCategoryTests : TestBase
    {
        [Fact]
        public async void AddCategory_CorrectData_ReturnsIdCategory()
        {
            var cmd = new AddCategoryCommand
            {
                Name = "test"
            };

            var handler = new AddCategoryCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }
    }
}