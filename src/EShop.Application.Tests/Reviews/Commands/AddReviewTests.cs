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
        public async void AddReview_CorrectData_ReturnsReviewId()
        {
            var cmd = new AddReviewCommand(UserId, 1, "test", 3);
            var handler = new AddReviewCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }

        [Fact]
        public async void AddReview_IncorrectProductId_ThrowsException()
        {
            var cmd = new AddReviewCommand(UserId, 123456, "test", 3);
            var handler = new AddReviewCommandHandler(GetProductsContext());

            await Assert.ThrowsAsync<DbUpdateException>(async () =>
                                                                await handler.Handle(cmd, CancellationToken.None));
        }

        [Fact]
        public async void AddReview_IncorrectUserId_ThrowsException()
        {
            var cmd = new AddReviewCommand(Guid.NewGuid().ToString(), 1, "test", 3);
            var handler = new AddReviewCommandHandler(GetProductsContext());

            await Assert.ThrowsAsync<DbUpdateException>(async () =>
                                                                await handler.Handle(cmd, CancellationToken.None));
        }
    }
}