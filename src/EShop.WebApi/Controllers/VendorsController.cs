using EShop.Application.Products.Commands.AddVendor;
using EShop.Application.Products.Commands.DeleteVendor;
using EShop.Application.Products.Commands.EditVendor;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddVendor([FromBody] AddVendorCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPut]
        public async Task<ActionResult<Vendor>> EditVendor([FromBody] EditVendorCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteVendor([FromBody] DeleteVendorCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}
