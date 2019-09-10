using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetProductsQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetProductsQueryHandler>();
        }

        public Task<ProductsViewModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение всех продуктов");
            return Task.FromResult(new ProductsViewModel
            {
                Products = _db.Products.Include(x => x.Category).Include(x => x.Vendor).ToArray()
            });
        }
    }
}