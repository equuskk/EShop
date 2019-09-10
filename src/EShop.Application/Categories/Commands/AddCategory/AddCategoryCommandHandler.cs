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
            var category = new Category(request.Name);

            _logger.Debug("Добавление новой категории с именем {0}", request.Name);

            _db.Categories.Add(category);

            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Категория с именем {0} добавлена. ID категории {1}", request.Name, category.Id);

            return category.Id;
        }
    }
}