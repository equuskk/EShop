using System.Threading.Tasks;
using EShop.Application.Vendors.Commands.AddVendor;
using EShop.Application.Vendors.Commands.DeleteVendor;
using EShop.Application.Vendors.Queries.GetVendors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VendorsController : Controller
    {
        private readonly IMediator _mediator;

        public VendorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var vendors = await _mediator.Send(new GetVendorsQuery());
            return View(vendors);
        }

        public IActionResult AddView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name, string description)
        {
            await _mediator.Send(new AddVendorCommand(name, description));
            return RedirectToAction("Index", "Vendors");
        }

        //TODO: post
        public async Task<IActionResult> Delete(int vendorId)
        {
            await _mediator.Send(new DeleteVendorCommand(vendorId));
            return RedirectToAction("Index", "Vendors");
        }
    }
}