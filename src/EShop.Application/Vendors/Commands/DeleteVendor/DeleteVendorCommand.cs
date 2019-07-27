using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Vendors.Commands.DeleteVendor
{
    public class DeleteVendorCommand : IRequest<Unit>
    {
        public int VendorId { get; }

        [JsonConstructor]
        public DeleteVendorCommand(int vendorId)
        {
            VendorId = vendorId;
        }
    }
}