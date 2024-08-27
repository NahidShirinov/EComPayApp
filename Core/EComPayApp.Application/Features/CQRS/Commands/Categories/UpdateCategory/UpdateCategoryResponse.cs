using EComPayApp.Application.DTOs.CategoryDtos;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetCategoryDto Category { get; set; }

    }
}
