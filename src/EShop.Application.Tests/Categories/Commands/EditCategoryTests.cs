﻿using System.Threading;
using EShop.Application.Categories.Commands.EditCategory;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Categories.Commands
{
    public class EditCategoryTests : TestBase
    {
        [Fact]
        public async void EditCategory_CorrectId_ReturnsCategory()
        {
            var cmd = new EditCategoryCommand(1, "test");
            var handler = new EditCategoryCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Category>(result);
            Assert.Equal(cmd.CategoryId, result.Id);
            Assert.Equal(cmd.Name, result.Name);
        }

        [Fact]
        public async void EditCategory_IncorrectId_ThrowsException()
        {
            var cmd = new EditCategoryCommand(-1, "test");
            var handler = new EditCategoryCommandHandler(GetDbContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}