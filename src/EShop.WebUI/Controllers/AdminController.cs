using System.IO;
using System.Threading.Tasks;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Vendors.Queries.GetVendors;
using EShop.Domain.Entities;
using EShop.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly Helpers.Helpers _helpers;
        private readonly UserManager<ShopUser> _manager;
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator, Helpers.Helpers helpers, UserManager<ShopUser> manager,
            IHostingEnvironment appEnvironment)
        {
            _mediator = mediator;
            _helpers = helpers;
            _manager = manager;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            await _mediator.Send(new DeleteProductCommand(ProductId));
            return RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> AddProductView()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            var vendors = await _mediator.Send(new GetVendorsQuery());


            return View(new AddProductViewModels{Categories = categories, Vendors = vendors});
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string title, string description, int price, IFormFile file, int vendorID, int categoryId)
        {
            if (file != null)
            {
                // путь к папке Files
                var path = "/Images/ProductImages/" + file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                await _mediator.Send(new AddProductCommand(title, description, price, vendorID, categoryId, file.FileName));
                return RedirectToAction("Index", "Products");
            }

            return RedirectToAction("Index", "Products");
        }
    }
}