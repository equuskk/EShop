using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using MediatR;
using Serilog;

namespace EShop.Application.Products.Queries.GetProductsByVendor
{
    public class GetProductsByVendorQueryHandler : IRequestHandler<GetProductsByVendorQuery, ProductsViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetProductsByVendorQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetProductsByVendorQueryHandler>();
        }

        public Task<ProductsViewModel> Handle(GetProductsByVendorQuery request,
                                              CancellationToken cancellationToken)
        {
            _logger.Debug("Получение продуктов поставщика {0}", request.VendorId);

            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.Where(x => x.VendorId == request.VendorId).ToArray()
            });
        }
    }
}