using System.IO;
using System.Threading.Tasks;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Products.Commands.AddProduct;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Application.Products.Commands.EditProduct;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Application.Products.Queries.GetProducts;
using EShop.Application.Reviews.Queries.GetReviewsByProductId;
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
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator, IWebHostEnvironment appEnvironment)
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

            var path = Path.Combine(_appEnvironment.WebRootPath, "Images", "ProductImages", file.FileName);

            // сохраняем файл в папку Files в каталоге wwwroot
            using(var fileStream = new FileStream(path, FileMode.Create))
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

        [HttpGet]
        public async Task<IActionResult> EditView(int productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            var review = await _mediator.Send(new GetReviewsByProductIdQuery(productId));

            var productViewModel = new ProductViewModels { Product = product, Reviews = review };

            var categories = await _mediator.Send(new GetCategoriesQuery());
            var vendors = await _mediator.Send(new GetVendorsQuery());

            var commonData = new AddProductViewModels { Categories = categories, Vendors = vendors };
            return View("Edit", new EditProductViewModels
            {
                Product = productViewModel,
                CommonData = commonData
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string title, string description, double price,
                                              int vendorId, int categoryId, int productId)
        {
            await _mediator.Send(new EditProductCommand(productId, title, price, description, vendorId, categoryId));
            return RedirectToAction("Index", "Products");
        }
    }
}