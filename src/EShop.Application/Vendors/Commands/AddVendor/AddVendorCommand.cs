using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Vendors.Commands.AddVendor
{
    public class AddVendorCommand : IRequest<int>
    {
        public string Name { get; }

        public string Description { get; }

        [JsonConstructor]
        public AddVendorCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}