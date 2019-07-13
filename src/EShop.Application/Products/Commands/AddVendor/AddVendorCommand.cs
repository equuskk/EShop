using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.AddVendor
{
    public class AddVendorCommand : IRequest<int>
    {
        public string Name { get;  set; }

        public string Description { get;  set; }
    }
}
