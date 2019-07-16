using System.Security.Claims;
using System.Threading.Tasks;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.AddProductInCart;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Products.Commands.DeleteProductFromCart;
using EShop.Application.Products.Commands.EditProduct;
using EShop.Application.Products.Commands.MakeOrder;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.Application.Products.Queries.GetProductByCategory;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Application.Products.Queries.GetProductByVendor;
using EShop.Application.Reviews.Commands.AddReview;
using EShop.Application.Reviews.Commands.DeleteReview;
using EShop.Application.Reviews.Queries.GetAllReviewsByProductId;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ProductsViewModel>> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        [HttpGet("byVendor/{id}")]
        public async Task<ActionResult<ProductsViewModel>> GetProductsByVendor(int id)
        {
            return Ok(await _mediator.Send(new GetProductByVendorQuery { VendorId = id }));
        }

        [HttpGet("byCategory/{id}")]
        public async Task<ActionResult<ProductsViewModel>> GetProductsByCategory(int id)
        {
            return Ok(await _mediator.Send(new GetProductByCategoryQuery { CategoryId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddProduct([FromBody] AddProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct([FromBody] EditProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct([FromBody] DeleteProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpGet("Reviews/{id}")]
        public async Task<ActionResult<ReviewsViewModel>> GetReviewsById(int id)
        {
            return Ok(await _mediator.Send(new GetAllReviewsByProductIdQuery { ProductId = id }));
        }

        [Authorize]
        [HttpDelete("Review/{id}")]
        public async Task<ActionResult<bool>> DeleteReview(int id)
        {
            return Ok(await _mediator.Send(new DeleteReviewCommand
            {
                Id = id,
                ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            }));
        }

        [Authorize]
        [HttpPost("AddReview")]
        public async Task<ActionResult<int>> AddReview([FromBody] AddReviewCommand cmd)
        {
            cmd.ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(cmd));
        }

        [Authorize]
        [HttpPost("AddProductInCart")]
        public async Task<ActionResult<int>> AddProductInCart([FromBody] AddProductInCartCommand cmd)
        {
            cmd.ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(cmd));
        }

        [Authorize]
        [HttpDelete("DeleteProductFromCart")]
        public async Task<ActionResult<bool>> DeleteProductFromCart([FromBody] DeleteProductFromCartCommand cmd)
        {
            cmd.ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _mediator.Send(cmd));
        }

        [Authorize]
        [HttpGet("Payment")]
        public async Task<ActionResult<ProductsViewModel>> OrderPayment()
        {
            return Ok(await _mediator.Send(new MakeOrderCommand
            {
                ShopUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            }));
        }
    }
}