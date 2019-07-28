using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public int CategoryId { get; }

        [JsonConstructor]
        public DeleteCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}