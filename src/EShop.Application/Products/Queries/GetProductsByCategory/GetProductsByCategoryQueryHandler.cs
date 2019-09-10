using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using MediatR;
using Serilog;

namespace EShop.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, ProductsViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetProductsByCategoryQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetProductsByCategoryQueryHandler>();
        }

        public Task<ProductsViewModel> Handle(GetProductsByCategoryQuery request,
                                              CancellationToken cancellationToken)
        {
            _logger.Debug("Получение продуктов в категории {0}", request.CategoryId);
            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.CategoryId == request.CategoryId).ToArray()
            });
        }
    }
}