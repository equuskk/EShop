using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}