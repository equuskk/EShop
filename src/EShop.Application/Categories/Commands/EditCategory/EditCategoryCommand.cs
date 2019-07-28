using EShop.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Categories.Commands.EditCategory
{
    public class EditCategoryCommand : IRequest<Category>
    {
        public int CategoryId { get; }
        public string Name { get; }

        [JsonConstructor]
        public EditCategoryCommand(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}