using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.CategoryDtos
{
    public class UpdateCategoryDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetProductDto> Products { get; set; }
    }
}
