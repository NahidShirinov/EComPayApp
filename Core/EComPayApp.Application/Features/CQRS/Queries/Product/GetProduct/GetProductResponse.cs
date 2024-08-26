using EComPayApp.Application.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct
{
    public class GetProductResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetProductDto Product { get; set; }
    }
}
