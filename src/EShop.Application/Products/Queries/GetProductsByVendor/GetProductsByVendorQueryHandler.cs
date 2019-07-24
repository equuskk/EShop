using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductsByVendor
{
    public class GetProductsByVendorQueryHandler : IRequestHandler<GetProductsByVendorQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetProductsByVendorQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public Task<ProductsViewModel> Handle(GetProductsByVendorQuery request,
                                                    CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.VendorId == request.VendorId).ToArray()
            });
        }
    }
}