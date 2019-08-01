using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Vendors.Queries.GetVendors;
using MediatR;

namespace Eshop.WebUI.Helper
{
    public class Helpers
    {
        private readonly IMediator _mediator;

        public Helpers(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CategoriesViewModel> GetAllCategories()
        {
            return await _mediator.Send(new GetCategoriesQuery());
        }

        public async Task<VendorsViewModel> GetAllVendors()
        {
            return await _mediator.Send(new GetVendorsQuery());
        }
    }
}
