using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Serilog;

namespace EShop.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, CategoriesViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetCategoriesQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetCategoriesQueryHandler>();
        }

        public Task<CategoriesViewModel> Handle(GetCategoriesQuery request,
                                                CancellationToken cancellationToken)
        {
            _logger.Debug("Получение всех категорий");
            return Task.FromResult(new CategoriesViewModel
            {
                Categories = _db.Categories.ToArray()
            });
        }
    }
}