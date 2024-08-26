using AutoMapper;
using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.DTOs.CategoryDtos;
using EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetCategoryHandler:IRequestHandler<GetCategoryQuery,GetCategoryResponse>
    {
        private readonly IReadRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryHandler(IReadRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return new GetCategoryResponse
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            var categoryDto = _mapper.Map<GetCategoryDto>(category);

            return new GetCategoryResponse
            {
                IsSuccess = true,
                Category = categoryDto
            };
        }
    }
}
