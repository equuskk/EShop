using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}