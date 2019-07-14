using EShop.Application.Categories.Commands.AddCategory;
using EShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands.Category
{
    public class AddCategoryTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public AddCategoryTest(ProductsDbContextFixture fixture)
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
