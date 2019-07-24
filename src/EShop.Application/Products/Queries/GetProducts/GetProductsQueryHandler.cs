using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetProductsQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public Task<ProductsViewModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.ToArray()
            });
        }
    }
}