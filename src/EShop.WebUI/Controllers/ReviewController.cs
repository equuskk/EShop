using System.Threading.Tasks;
using EShop.Application.Reviews.Commands.AddReview;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public ReviewController(IMediator mediator, UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _manager = manager;
        }

        [Authorize]
        public async Task<IActionResult> CreateReview(int productId, string text, int rate)
        {
            var user = await _manager.GetUserAsync(User);
            await _mediator.Send(new AddReviewCommand(user.Id, productId, text, rate));
            return RedirectToAction("Details", "Products", new { id = productId });
        }
    }
}