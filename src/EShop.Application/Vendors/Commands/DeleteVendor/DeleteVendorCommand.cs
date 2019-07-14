using MediatR;

namespace EShop.Application.Vendors.Commands.DeleteVendor
{
    public class DeleteVendorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}