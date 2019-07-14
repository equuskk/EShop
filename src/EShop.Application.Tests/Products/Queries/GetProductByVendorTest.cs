﻿using EShop.Application.Products.Queries.GetProductByVendor;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductByVendorTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetProductByVendorTest(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetProductById_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByVendorQuery
            {
                VendorId = 1
            };

            var handler = new GetProductByVendorQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(result.Products.First().VendorId, cmd.VendorId);
        }

        [Fact]
        public async void GetProductById_IncorrectId_ThrowsException()
        {
            var cmd = new GetProductByVendorQuery
            {
                VendorId = -1
            };

            var handler = new GetProductByVendorQueryHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
