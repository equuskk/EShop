using MediatR;

namespace EShop.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string Name { get;  set; }
    }
}
