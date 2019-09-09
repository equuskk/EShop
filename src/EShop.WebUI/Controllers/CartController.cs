using System.Threading.Tasks;
using EShop.Application.Cart.Commands.DeleteProductFromCart;
using EShop.Application.Cart.Queries.GetUserCart;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public CartController(IMediator mediator, UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _manager.GetUserAsync(User);
            var product = await _mediator.Send(new GetUserCartQuery(user.Id));
            return View(product);
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new DeleteProductFromCartCommand(id, 1, user.Id));
            var product = await _mediator.Send(new GetUserCartQuery(user.Id));
            return View("Index", product);
        }
    }
}