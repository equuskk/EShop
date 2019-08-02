using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Application.Products.Queries.GetProducts;
using EShop.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Helpers.Helpers _helpers;
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator, Helpers.Helpers helpers)
        {
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

        public async Task<IActionResult> Filter(string category, string vendor, string sort)
        {
            var products = (await _mediator.Send(new GetProductsQuery())).Products;

            if(!string.IsNullOrWhiteSpace(category) && category != "Любая")
            {
                products = products.Where(x => x.Category.Name == category).ToArray();
            }

            if(!string.IsNullOrWhiteSpace(vendor) && vendor != "Любой")
            {
                products = products.Where(x => x.Vendor.Name == vendor).ToArray();
            }

            if(!string.IsNullOrWhiteSpace(sort) && sort != "Не сортировать")
            {
                if(sort == "Сначала дорогие")
                {
                    products = products.OrderByDescending(x => x.Price).ToArray();
                }
                else
                {
                    products = products.OrderBy(x => x.Price).ToArray();
                }
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