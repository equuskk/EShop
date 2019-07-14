using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Products.Commands.AddCategory;
using EShop.Application.Products.Commands.DeleteCategory;
using EShop.Application.Products.Commands.EditCategory;
using EShop.Application.Products.Queries.GetAllCategories;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<CategoriesViewModel>> GetAllCategories()
        {
            return Ok(await _mediator.Send(new GetAllCategoriesQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCategory([FromBody] AddCategoryCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpPut]
        public async Task<ActionResult<Category>> EditCategory([FromBody] EditCategoryCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCategory([FromBody] DeleteCategoryCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}