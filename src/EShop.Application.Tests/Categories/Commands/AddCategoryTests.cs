using System.Threading;
using EShop.Application.Categories.Commands.AddCategory;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class AddCategoryTests : TestBase
    {
        [Fact]
        public async void AddCategory_CorrectData_ReturnsCategoryId()
        {
            var cmd = new AddCategoryCommand("test");
            var handler = new AddCategoryCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }
    }
}