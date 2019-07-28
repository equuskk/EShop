using System.Security.Claims;
using System.Threading.Tasks;
using EShop.Application.Cart.Commands.AddProductToCart;
using EShop.Application.Cart.Commands.DeleteProductFromCart;
using EShop.Application.Cart.Commands.MakeOrder;
using EShop.Application.Cart.Queries.GetUserCart;
using EShop.Application.Products.Queries.GetProducts;
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CartViewModel>> GetUserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cmd = new GetUserCartQuery(userId);
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddProductInCart([FromBody] AddProductToCartCommand cmd)
        {
            //TODO: fix it
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newCmd = new AddProductToCartCommand(userId, cmd.ProductId, cmd.Quantity);
            return Ok(await _mediator.Send(newCmd));
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteProductFromCart([FromBody] DeleteProductFromCartCommand cmd)
        {
            //TODO: fix it
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newCmd = new DeleteProductFromCartCommand(cmd.ProductId, cmd.Quantity, userId);
            return Ok(await _mediator.Send(newCmd));
        }

        [Authorize]
        [HttpPost("MakeOrder")]
        public async Task<ActionResult<ProductsViewModel>> MakeOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(new MakeOrderCommand(userId)));
        }
    }
}