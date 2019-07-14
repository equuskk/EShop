using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetAllProducts;
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

        public async Task<ProductsViewModel> Handle(GetProductByCategoryQuery request,
                                                    CancellationToken cancellationToken)
        {
            return new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.CategoryId == request.CategoryId).ToArray()
            };
        }
    }
}