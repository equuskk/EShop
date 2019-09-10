using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Categories.Commands.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Category>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public EditCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<EditCategoryCommandHandler>();
        }

        public async Task<Category> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FindAsync(request.CategoryId);
            _logger.Debug("Редактирование категории с ID {0}", request.CategoryId);

            if(category is null)
            {
                _logger.Debug("Категории с ID {0} не найдено", request.CategoryId);
                throw new NotFoundException(nameof(Product), request.CategoryId);
            }

            category.SetName(request.Name);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Редактирование категории с именем {0} завершено успешно", category.Name);

            return category;
        }
    }
}