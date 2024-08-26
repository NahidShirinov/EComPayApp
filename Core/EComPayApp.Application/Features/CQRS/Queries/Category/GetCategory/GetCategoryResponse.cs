using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.DTOs.CategoryDtos;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetCategoryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetCategoryDto Category { get; set; }
    }
}
