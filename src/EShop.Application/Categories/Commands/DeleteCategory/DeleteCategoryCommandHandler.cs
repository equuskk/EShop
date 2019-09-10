using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public DeleteCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<DeleteCategoryCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FindAsync(request.CategoryId);

            _logger.Debug("Удаление категории с ID {0}", request.CategoryId);

            if(category is null)
            {
                _logger.Debug("Категории с ID {0} не найдена", request.CategoryId);
                throw new NotFoundException(nameof(category), request.CategoryId);
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Категории с именем {0} удалена", category.Name);

            return Unit.Value;
        }
    }
}