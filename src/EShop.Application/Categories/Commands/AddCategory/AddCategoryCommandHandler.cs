using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Serilog;

namespace EShop.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public AddCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<AddCategoryCommandHandler>();
        }

        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Добавление категории {0}", request.Name);

            var category = new Category(request.Name);

            _db.Categories.Add(category);

            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Категория {0} добавлена", request.Name);

            return category.Id;
        }
    }
}