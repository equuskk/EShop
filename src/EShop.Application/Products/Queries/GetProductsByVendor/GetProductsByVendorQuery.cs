using EShop.Application.Products.Queries.GetProducts;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductsByVendor
{
    public class GetProductsByVendorQuery : IRequest<ProductsViewModel>
    {
        public int VendorId { get; }

        public GetProductsByVendorQuery(int vendorId)
        {
            VendorId = vendorId;
        }
    }
}