using EShop.Application.Products.Queries.GetProducts;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQuery : IRequest<ProductsViewModel>
    {
        public int CategoryId { get; set; }
    }
}