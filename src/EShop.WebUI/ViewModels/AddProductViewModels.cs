using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Vendors.Queries.GetVendors;

namespace EShop.WebUI.ViewModels
{
    public class AddProductViewModels
    {
        public CategoriesViewModel Categories { get; set; }
        public VendorsViewModel Vendors { get; set; }
    }
}