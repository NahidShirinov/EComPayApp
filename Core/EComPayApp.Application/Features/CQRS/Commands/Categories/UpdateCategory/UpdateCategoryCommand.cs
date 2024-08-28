using EComPayApp.Application.DTOs.ProductDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<UpdateCategoryResponse>
    {
        public string Name { get; set; }
        public ICollection<GetProductDto> Products { get; set; }
        public Guid Id { get; set; }

    }
}
