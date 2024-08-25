using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommand:IRequest<DeleteCategoryResponse>
    {
        public Guid Id { get; set; }

    }
}
