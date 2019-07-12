using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetAllProductsQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<ProductsViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return new ProductsViewModel
            {
                Products = _db.Products.ToArray()
            };
        }
    }
}