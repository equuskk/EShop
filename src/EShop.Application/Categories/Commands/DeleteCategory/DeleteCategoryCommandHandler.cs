using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public DeleteCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FindAsync(request.CategoryId);

            if(category is null)
            {
                throw new NotFoundException(nameof(category), request.CategoryId);
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}