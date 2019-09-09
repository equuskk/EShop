using System.IO;
using System.Threading.Tasks;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Products.Queries.GetProducts;
using EShop.Application.Vendors.Queries.GetVendors;
using EShop.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator, IHostingEnvironment appEnvironment)
        {
            _mediator = mediator;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return View(products);
        }
        
        public async Task<IActionResult> AddView()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            var vendors = await _mediator.Send(new GetVendorsQuery());

            return View("AddView", new AddProductViewModels { Categories = categories, Vendors = vendors });
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(string title, string description, int price, IFormFile file,
                                                    int vendorId, int categoryId)
        {
            if(file is null)
            {
                return RedirectToAction("Index", "Products");
            }

            // путь к папке Files
            var path = "/Images/ProductImages/" + file.FileName;

            // сохраняем файл в папку Files в каталоге wwwroot
            using(var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            await _mediator.Send(new AddProductCommand(title, description, price, vendorId, categoryId,
                                                       file.FileName));
            return RedirectToAction("Index", "Products");

        }
        
        public async Task<IActionResult> Delete(int productId)
        {
            await _mediator.Send(new DeleteProductCommand(productId));
            return RedirectToAction("Index", "Products");
        }
    }
}