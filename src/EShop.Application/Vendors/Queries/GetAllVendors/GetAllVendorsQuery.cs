using EShop.Application.Vendors.Queries.GetAllVendors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Vendors.Queries
{
    public class GetAllVendorsQuery : IRequest<VendorsViewModel>
    {
    }
}
