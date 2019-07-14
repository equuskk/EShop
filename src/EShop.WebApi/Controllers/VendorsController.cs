using System.Threading.Tasks;
using EShop.Application.Vendors.Commands.AddVendor;
using EShop.Application.Vendors.Commands.DeleteVendor;
using EShop.Application.Vendors.Commands.EditVendor;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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