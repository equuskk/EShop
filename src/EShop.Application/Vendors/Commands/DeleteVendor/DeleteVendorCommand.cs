using MediatR;

namespace EShop.Application.Vendors.Commands.DeleteVendor
{
    public class DeleteVendorCommand : IRequest<Unit>
    {
        public int VendorId { get; set; }
    }
}