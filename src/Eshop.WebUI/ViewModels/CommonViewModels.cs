using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Application.Categories.Queries.GetCategories;
using EShop.Application.Products.Queries.GetProducts;
using EShop.Application.Vendors.Queries.GetVendors;

namespace Eshop.WebUI.ViewModels
{
    public class CommonViewModels
    {
        public ProductsViewModel Products { get; set; }
        public CategoriesViewModel Categories { get; set; }
        public VendorsViewModel Vendors { get; set; }
    }
}
