using EShop.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ProductId { get; }

        [JsonConstructor]
        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}