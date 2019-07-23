using System.Security.Claims;
using System.Threading.Tasks;
using EShop.Application.Products.Commands.AddProductInCart;
using EShop.Application.Products.Commands.DeleteProductFromCart;
using EShop.Application.Products.Commands.MakeOrder;
using EShop.Application.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddProductInCart([FromBody] AddProductInCartCommand cmd)
        {
            cmd.ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteProductFromCart([FromBody] DeleteProductFromCartCommand cmd)
        {
            cmd.ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(cmd));
        }

        [Authorize]
        [HttpPost("MakeOrder")]
        public async Task<ActionResult<ProductsViewModel>> MakeOrder()
        {
            return Ok(await _mediator.Send(new MakeOrderCommand
            {
                ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            }));
        }
    }
}