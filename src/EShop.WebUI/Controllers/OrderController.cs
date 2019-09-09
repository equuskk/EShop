using System.Threading.Tasks;
using EShop.Application.Cart.Commands.MakeOrder;
using EShop.Application.Cart.Queries.GetUserOrder;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public OrderController(IMediator mediator, UserManager<ShopUser> manager)
        {
            _manager = manager;
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IActionResult> MakeOrder()
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new MakeOrderCommand(user.Id));
            return View("Success");
        }

        [Authorize]
        public async Task<IActionResult> GetOrder()
        {
            var user = await _manager.GetUserAsync(User);
            var order = await _mediator.Send(new GetUserOrderCommand(user.Id));
            return View("Index", order);
        }
    }
}