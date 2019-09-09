using System.IO;
using System.Threading.Tasks;
using EShop.Application.Categories.Commands.AddCategory;
using EShop.Application.Categories.Commands.DeleteCategory;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Vendors.Commands.AddVendor;
using EShop.Application.Vendors.Commands.DeleteVendor;
using EShop.Application.Vendors.Queries.GetVendors;
using EShop.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator, IHostingEnvironment appEnvironment)
        {
            _mediator = mediator;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _mediator.Send(new DeleteProductCommand(productId));
            return RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> DeleteVendorView()
        {
            var model = await _mediator.Send(new GetVendorsQuery());
            return View("Remove/DeleteVendorView", model);
        }

        public async Task<IActionResult> DeleteVendor(int vendorId)
        {
            await _mediator.Send(new DeleteVendorCommand(vendorId));
            return RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> DeleteCategoryView()
        {
            var model = await _mediator.Send(new GetCategoriesQuery());
            return View("Remove/DeleteCategoryView", model);
        }

        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand(categoryId));
            return RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> AddProductView()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            var vendors = await _mediator.Send(new GetVendorsQuery());


            return View("Add/AddProductView", new AddProductViewModels { Categories = categories, Vendors = vendors });
        }

        public IActionResult AddVendorView()
        {
            return View("Add/AddVendorView");
        }

        public async Task<IActionResult> AddVendor(string name, string description)
        {
            await _mediator.Send(new AddVendorCommand(name, description));
            return RedirectToAction("Index", "Products");
        }

        public IActionResult AddCategoryView()
        {
            return View("Add/AddCategoryView");
        }

        public async Task<IActionResult> AddCategory(string name)
        {
            await _mediator.Send(new AddCategoryCommand(name));
            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string title, string description, int price, IFormFile file,
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
    }
}