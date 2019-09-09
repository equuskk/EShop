using System.Threading.Tasks;
using EShop.Application.Categories.Commands.AddCategory;
using EShop.Application.Categories.Commands.DeleteCategory;
using EShop.Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return View(categories);
        }
        
        public IActionResult AddView()
        {
            return View("AddView");
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            await _mediator.Send(new AddCategoryCommand(name));
            return RedirectToAction("Index", "Categories");
        }
        
        //TODO: post
        public async Task<IActionResult> Delete(int categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand(categoryId));
            return RedirectToAction("Index", "Categories");
        }
    }
}