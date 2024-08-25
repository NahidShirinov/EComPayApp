using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Products.UpdateProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryHandler:IRequestHandler<UpdateCategoryCommand,UpdateCategoryResponse>
    {
        private readonly IWriteRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IWriteRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return new UpdateCategoryResponse
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            _mapper.Map(request, category);

            var result = _repository.Update(category);
            await _repository.SaveAsync();

            return new UpdateCategoryResponse
            {
                IsSuccess = result,
                Message = result ? "Category updated successfully" : "Update failed"
            };
        }
    }
}
