using System.Security.Claims;
using System.Threading.Tasks;
using EShop.Application.Reviews.Commands.AddReview;
using EShop.Application.Reviews.Commands.DeleteReview;
using EShop.Application.Reviews.Queries.GetReviewsByProductId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewsViewModel>> GetReviewsByProductId(int productId)
        {
            return Ok(await _mediator.Send(new GetReviewsByProductIdQuery(productId)));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddReview([FromBody] AddReviewCommand cmd)
        {
            //TODO: fix it
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newCmd = new AddReviewCommand(userId, cmd.ProductId, cmd.Text, cmd.Rate);
            return Ok(await _mediator.Send(newCmd));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteReview(int reviewId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(new DeleteReviewCommand(reviewId, userId)));
        }
    }
}