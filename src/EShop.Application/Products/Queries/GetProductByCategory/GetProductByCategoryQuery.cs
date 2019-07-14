using EShop.Application.Products.Queries.GetAllProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Queries.GetProductByCategory
{
    public class GetProductByCategoryQuery : IRequest<ProductsViewModel>
    {
        public int CategooryId { get; set; }
    }
}
