using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Vendors.Commands.EditVendor
{
    public class EditVendorCommand : IRequest<Vendor>
    {
        public int VendorId { get; }
        public string Name { get; }
        public string Description { get; }

        public EditVendorCommand(int vendorId, string name, string description)
        {
            VendorId = vendorId;
            Name = name;
            Description = description;
        }
    }
}