using MediatR;

namespace EShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public int CategoryId { get; set; }
    }
}