using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.CategoryDtos
{
    public class CreateCategoryDto : IDto
    {
        public string Name { get; set; }
        public ICollection<GetProductDto> Products { get; set; } = new List<GetProductDto>();
    }
}
