using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.EditCategory
{
    public class EditCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
