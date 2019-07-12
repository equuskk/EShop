using MediatR;

namespace EShop.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ProductsViewModel>
    {
    }
}