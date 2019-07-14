using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Categories.Commands.EditCategory
{
    public class EditCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}