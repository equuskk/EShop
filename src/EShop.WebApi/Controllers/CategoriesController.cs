using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Products.Commands.AddCategory;
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

        [HttpPost]
        public async Task<ActionResult<int>> AddCategory([FromBody] AddCategoryCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}