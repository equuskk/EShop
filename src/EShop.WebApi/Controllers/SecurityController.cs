using System.Threading.Tasks;
using EShop.Application.Users.Commands.AuthUser;
using EShop.Application.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SecurityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterUserCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Authorize([FromBody] AuthUserCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}