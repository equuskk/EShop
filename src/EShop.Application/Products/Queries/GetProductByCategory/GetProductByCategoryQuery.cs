using EShop.Application.Products.Queries.GetAllProducts;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductByCategory
{
    public class GetProductByCategoryQuery : IRequest<ProductsViewModel>
    {
        public int CategoryId { get; set; }
    }
}