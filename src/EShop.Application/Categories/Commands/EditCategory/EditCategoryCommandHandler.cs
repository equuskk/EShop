using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Categories.Commands.EditCategory
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Category>
    {
        private readonly ProductsDbContext _db;

        public EditCategoryCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<Category> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FindAsync(request.Id);

            if(category is null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            category.SetName(request.Name);
            await _db.SaveChangesAsync(cancellationToken);

            return category;
        }
    }
}