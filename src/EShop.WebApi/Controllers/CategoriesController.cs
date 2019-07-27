using System.Threading.Tasks;
using EShop.Application.Categories.Commands.AddCategory;
using EShop.Application.Categories.Commands.DeleteCategory;
using EShop.Application.Categories.Commands.EditCategory;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CategoriesViewModel>> GetCategories()
        {
            return Ok(await _mediator.Send(new GetCategoriesQuery()));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> AddCategory([FromBody] AddCategoryCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Category>> EditCategory([FromBody] EditCategoryCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete("{categoryId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteCategory(int categoryId)
        {
            var cmd = new DeleteCategoryCommand(categoryId);
            return Ok(await _mediator.Send(cmd));
        }
    }
}