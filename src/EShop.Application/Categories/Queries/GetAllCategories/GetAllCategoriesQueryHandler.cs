using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoriesViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetAllCategoriesQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }
        public async Task<CategoriesViewModel> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return new CategoriesViewModel
            {
                Categories = _db.Categories.ToArray()
            };
        }
    }
}
