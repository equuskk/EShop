using EShop.Application.Products.Queries.GetProducts;
using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQuery : IRequest<ProductsViewModel>
    {
        public int CategoryId { get; }

        [JsonConstructor]
        public GetProductsByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}