using MediatR;

namespace EShop.Application.Vendors.Commands.AddVendor
{
    public class AddVendorCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}