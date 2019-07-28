using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetProductsQueryHandler(ApplicationDbContext db)
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