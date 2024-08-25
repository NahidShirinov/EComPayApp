using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryHandler:IRequestHandler<DeleteCategoryCommand,DeleteCategoryResponse>
    {
        private readonly IWriteRepository<Category> _repository;

        public DeleteCategoryHandler(IWriteRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return new DeleteCategoryResponse
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            var result = _repository.Remove(category);
            await _repository.SaveAsync();

            return new DeleteCategoryResponse
            {
                IsSuccess = result,
                Message = result ? "Category deleted successfully" : "Delete failed"
            };
        }
    }
}
