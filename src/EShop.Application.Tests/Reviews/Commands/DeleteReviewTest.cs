using EShop.Application.Reviews.Commands.DeleteReview;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Reviews.Commands
{
    public class DeleteReviewTest : TestBase
    {

        [Fact]
        public async void DeleteReview_CorrectData_ReturnsTrue()
        {
            var cmd = new DeleteReviewCommand
            {
                Id = 1
            };

            var handler = new DeleteReviewCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteReviewCommand
            {
                Id = -1
            };

            var handler = new DeleteReviewCommandHandler(GetProductsContext());
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
