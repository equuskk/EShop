using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.EditVendor
{
    public class EditVendorCommand : IRequest<Vendor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
