using System.Threading.Tasks;
using EShop.Application.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterUserCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}