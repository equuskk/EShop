using EShop.Application.Products.Commands.DeleteCategory;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands.Category
{
    public class DeleteCategoryTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public DeleteCategoryTest(ProductsDbContextFixture fixture)
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
