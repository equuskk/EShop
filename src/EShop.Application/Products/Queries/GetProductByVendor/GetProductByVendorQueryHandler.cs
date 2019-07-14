using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductByVendor
{
    public class GetProductByVendorQueryHandler : IRequestHandler<GetProductByVendorQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetProductByVendorQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<ProductsViewModel> Handle(GetProductByVendorQuery request, CancellationToken cancellationToken)
        {
            return new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.VendorId == request.VendorId).ToArray()
            };
        }
    }
}