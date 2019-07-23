using EShop.Application.Products.Queries.GetProducts;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductByVendor
{
    public class GetProductByVendorQuery : IRequest<ProductsViewModel>
    {
        public int VendorId { get; set; }
    }
}