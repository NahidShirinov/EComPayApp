using EComPayApp.Application.DTOs.CategoryDtos;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.CreateCategory
{
    public class CreateCategoryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetCategoryDto Category { get; set; }
    }
}
