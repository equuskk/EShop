﻿using System.Threading.Tasks;
using EShop.Application.Categories.Commands.AddCategory;
using EShop.Application.Categories.Commands.DeleteCategory;
using EShop.Application.Categories.Commands.EditCategory;
using EShop.Domain.Entities;
using MediatR;
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