using System.Threading.Tasks;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Products.Commands.EditProduct;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.Application.Products.Queries.GetProductByCategory;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Application.Products.Queries.GetProductByVendor;
using EShop.Domain.Entities;
using MediatR;
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
        public async Task<ActionResult<Product>> DeleteProduct([FromBody] DeleteProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}