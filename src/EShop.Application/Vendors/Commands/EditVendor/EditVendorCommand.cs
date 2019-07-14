using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Vendors.Commands.EditVendor
{
    public class EditVendorCommand : IRequest<Vendor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
