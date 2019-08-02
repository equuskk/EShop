using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Application.Products.Queries.GetProducts;
using EShop.DataAccess;
using Eshop.WebUI.Helper;
using Eshop.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly Helpers _helpers;
        private readonly IMediator _mediator;

        public ProductController(ApplicationDbContext db, IMediator mediator, Helpers helpers)
        {
            _db = db;
            _mediator = mediator;
            _helpers = helpers;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            var categories = await _helpers.GetAllCategories();
            var vendors = await _helpers.GetAllVendors();

            var model = new CommonViewModels
            {
                Categories = categories,
                Products = products,
                Vendors = vendors
            };

            return View(model);
        }

        public async Task<IActionResult> Filter(string CategoryName, string VendorName, string Sotrted)
        {
            var products = (await _mediator.Send(new GetProductsQuery())).Products;

            if (CategoryName != "Любая" && !string.IsNullOrWhiteSpace(CategoryName))
                products = products.Where(x => x.Category.Name == CategoryName).ToArray();

            if (VendorName != "Любой" && !string.IsNullOrWhiteSpace(VendorName))
                products = products.Where(x => x.Vendor.Name == VendorName).ToArray();

            if (Sotrted != "Не сортировать" && !string.IsNullOrWhiteSpace(Sotrted))
            {
                if (Sotrted == "Сначала дорогие")
                    products = products.OrderByDescending(x => x.Price).ToArray();
                else
                    products = products.OrderBy(x => x.Price).ToArray();
            }


            var categories = await _helpers.GetAllCategories();
            var vendors = await _helpers.GetAllVendors();

            var model = new CommonViewModels
            {
                Categories = categories,
                Products = new ProductsViewModel { Products = products },
                Vendors = vendors
            };
            return View("Index", model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return View(product);
        }
    }
}