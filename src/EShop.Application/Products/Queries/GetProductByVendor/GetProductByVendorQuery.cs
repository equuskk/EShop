using EShop.Application.Products.Queries.GetAllProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Queries.GetProductByVendor
{
    public class GetProductByVendorQuery : IRequest<ProductsViewModel>
    {
        public int VendorId { get; set; }
    }
}
