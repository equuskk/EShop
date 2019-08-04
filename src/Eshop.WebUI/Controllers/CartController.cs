﻿using System.Threading.Tasks;
using EShop.Application.Cart.Queries.GetUserCart;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly Helpers.Helpers _helpers;
        private readonly IMediator _mediator;
        private readonly UserManager<ShopUser> _manager;

        public CartController(IMediator mediator, Helpers.Helpers helpers, UserManager<ShopUser> manager)
        {
            _mediator = mediator;
            _helpers = helpers;
            _manager = manager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _manager.GetUserAsync(User);
            var product = await _mediator.Send(new GetUserCartQuery(user.Id));
            return View(product);
        }
    }
}