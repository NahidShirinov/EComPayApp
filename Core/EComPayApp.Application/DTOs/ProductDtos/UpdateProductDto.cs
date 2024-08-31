using EComPayApp.Application.DTOs.ImageDtos;
using EComPayApp.Application.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.DTOs.ProductDtos
{
    public class UpdateProductDto:IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BranchId { get; set; }
        public List<UpdateImageDto> Images { get; set; } = new List<UpdateImageDto>();
    }
}
