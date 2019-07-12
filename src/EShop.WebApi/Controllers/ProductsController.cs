using System.Threading.Tasks;
using EShop.Application.Products.Commands.CreateNewProduct;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.Application.Products.Queries.GetProductById;
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

        [HttpPost]
        public async Task<ActionResult<int>> AddProduct([FromBody] AddProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}