using System.Security.Claims;
using System.Threading.Tasks;
using EShop.Application.Reviews.Commands.AddReview;
using EShop.Application.Reviews.Commands.DeleteReview;
using EShop.Application.Reviews.Queries.GetAllReviewsByProductId;
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
            return Ok(await _mediator.Send(new GetAllReviewsByProductIdQuery { ProductId = productId }));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddReview([FromBody] AddReviewCommand cmd)
        {
            cmd.ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteReview(int reviewId)
        {
            return Ok(await _mediator.Send(new DeleteReviewCommand
            {
                Id = reviewId,
                ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            }));
        }
    }
}