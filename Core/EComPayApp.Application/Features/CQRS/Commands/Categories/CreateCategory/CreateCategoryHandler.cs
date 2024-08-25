using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Branches.CreateBranch;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.CreateCategory
{
    public class CreateCategoryHandler:IRequestHandler<CreateCategoryCommand,CreateCategoryResponse>
    {
        private readonly IWriteRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IWriteRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            var result = await _repository.AddAsync(category);
            await _repository.SaveAsync();

            return new CreateCategoryResponse
            {
                IsSuccess = result,
                Message = result ? "Category created successfully" : "Creation failed"
            };
        }
    }
}
