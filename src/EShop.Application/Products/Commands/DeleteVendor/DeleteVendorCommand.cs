using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.DeleteVendor
{
    public class DeleteVendorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
