using MediatR;

namespace EShop.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ProductsViewModel>
    {
    }
}