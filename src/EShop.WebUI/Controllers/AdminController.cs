using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly Helpers.Helpers _helpers;
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public AdminController(IMediator mediator, Helpers.Helpers helpers, UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _helpers = helpers;
            _manager = manager;
        }
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            await _mediator.Send(new DeleteProductCommand(ProductId));
            return RedirectToAction("Index", "Products");
        }
    }
}