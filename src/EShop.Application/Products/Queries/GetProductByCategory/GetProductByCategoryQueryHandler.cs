using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductByCategory
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetProductByCategoryQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public Task<ProductsViewModel> Handle(GetProductByCategoryQuery request,
                                                    CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.CategoryId == request.CategoryId).ToArray()
            });
        }
    }
}