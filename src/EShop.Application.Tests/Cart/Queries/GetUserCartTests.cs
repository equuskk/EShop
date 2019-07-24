using System.Threading;
using EShop.Application.Cart.Queries.GetUserCart;
using Xunit;

namespace EShop.Application.Tests.Cart.Queries
{
    public class GetUserCartTests : TestBase
    {
        [Fact]
        public async void GetUserCart_CorrectUserId_ReturnsCart()
        {
            var cmd = new GetUserCartQuery
            {
                ShopUserId = UserId
            };
            var handler = new GetUserCartQueryHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);
            
            Assert.NotEmpty(result.Products);
            Assert.True(result.TotalCost > 0);
        }
    }
}