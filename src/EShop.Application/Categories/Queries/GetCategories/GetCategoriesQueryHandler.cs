using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, CategoriesViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetCategoriesQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public Task<CategoriesViewModel> Handle(GetCategoriesQuery request,
                                                      CancellationToken cancellationToken)
        {
            return Task.FromResult(new CategoriesViewModel
            {
                Categories = _db.Categories.ToArray()
            });
        }
    }
}