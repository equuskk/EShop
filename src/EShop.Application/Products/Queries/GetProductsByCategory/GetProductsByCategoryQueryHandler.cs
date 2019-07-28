using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, ProductsViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetProductsByCategoryQueryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<ProductsViewModel> Handle(GetProductsByCategoryQuery request,
                                              CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.CategoryId == request.CategoryId).ToArray()
            });
        }
    }
}