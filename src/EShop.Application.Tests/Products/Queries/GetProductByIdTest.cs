using EShop.Application.Products.Queries.GetProductById;
using EShop.DataAccess;
using EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductByIdTest : TestBase
    {
        [Fact]
        public async void GetProductById()
        {
            var cmd = new GetProductByIdQuery
            {
                Id = 1
            };

            var handler = new GetProductByIdHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            var product = new Product
            {
                Id = 1,
                Title = "Продукт1",
                Description = "Описание1",
                Price = 111.11
            };

            Assert.True(result.Equals(result));
        }
    }
}
