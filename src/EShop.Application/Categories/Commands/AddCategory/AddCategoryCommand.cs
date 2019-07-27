using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string Name { get; }

        [JsonConstructor]
        public AddCategoryCommand(string name)
        {
            Name = name;
        }
    }
}