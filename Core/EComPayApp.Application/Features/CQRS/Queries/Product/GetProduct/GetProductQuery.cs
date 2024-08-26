using EComPayApp.Application.DTOs.ProductDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct
{
    public class GetProductQuery : IRequest<GetProductResponse>
    {
        public Guid Id { get; set; }
    }
    
    
}
