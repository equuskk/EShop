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
            _logger.Debug("Редактирование категории {0}", request.CategoryId);

            var category = await _db.Categories.FindAsync(request.CategoryId);
            
            if(category is null)
            {
                _logger.Debug("Категория {0} не найдена", request.CategoryId);
                throw new NotFoundException(nameof(Product), request.CategoryId);
            }

            category.SetName(request.Name);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Редактирование категории {0} завершено успешно", request.CategoryId);

            return category;
        }
    }
}