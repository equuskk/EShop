using System.Threading.Tasks;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Products.Commands.EditProduct;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Application.Products.Queries.GetProducts;
using EShop.Application.Products.Queries.GetProductsByCategory;
using EShop.Application.Products.Queries.GetProductsByVendor;
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
        public async Task<ActionResult<ProductsViewModel>> GetProducts()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(productId)));
        }

        [HttpGet("byVendor/{vendorId}")]
        public async Task<ActionResult<ProductsViewModel>> GetProductsByVendor(int vendorId)
        {
            return Ok(await _mediator.Send(new GetProductsByVendorQuery(vendorId)));
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<ActionResult<ProductsViewModel>> GetProductsByCategory(int categoryId)
        {
            return Ok(await _mediator.Send(new GetProductsByCategoryQuery(categoryId)));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddProduct([FromBody] AddProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Product>> EditProduct([FromBody] EditProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteProduct(int productId)
        {
            var cmd = new DeleteProductCommand(productId);
            return Ok(await _mediator.Send(cmd));
        }
    }
}