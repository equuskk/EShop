using System;
using System.Threading;
using EShop.Application.Reviews.Commands.AddReview;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EShop.Application.Tests.Reviews.Commands
{
    public class AddReviewTests : TestBase
    {
        [Fact]
        public async void AddReview_CorrectData_ReturnsId()
        {
            var cmd = new AddReviewCommand
            {
                ProductId = 1,
                Rate = 3,
                ShopUserId = UserId,
                Text = "test"
            };
            var handler = new AddReviewCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }

        [Fact]
        public async void AddReview_IncorrectProductId_ThrowsException()
        {
            var cmd = new AddReviewCommand
            {
                ProductId = 123456,
                Rate = 3,
                ShopUserId = UserId,
                Text = "test"
            };
            var handler = new AddReviewCommandHandler(GetProductsContext());

            await Assert.ThrowsAsync<DbUpdateException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }

        [Fact]
        public async void AddReview_IncorrectUserId_ThrowsException()
        {
            var cmd = new AddReviewCommand
            {
                ProductId = 123456,
                Rate = 3,
                ShopUserId = Guid.NewGuid().ToString(),
                Text = "test"
            };
            var handler = new AddReviewCommandHandler(GetProductsContext());

            await Assert.ThrowsAsync<DbUpdateException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}