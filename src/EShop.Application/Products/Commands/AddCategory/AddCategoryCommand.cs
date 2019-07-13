using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<int>
    {
        public string Name { get;  set; }
    }
}
