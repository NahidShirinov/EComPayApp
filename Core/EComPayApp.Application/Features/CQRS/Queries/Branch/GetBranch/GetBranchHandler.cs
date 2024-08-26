using AutoMapper;
using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.DTOs.BranchDtos;
using EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetBranchHandler:IRequestHandler<GetBranchQuery,GetBranchResponse>
    {
        private readonly IReadRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public GetBranchHandler(IReadRepository<Branch> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBranchResponse> Handle(GetBranchQuery request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id);

            if (branch == null)
            {
                return new GetBranchResponse
                {
                    IsSuccess = false,
                    Message = " Branch not found"
                };
            }

            var branchDto = _mapper.Map<GetBranchDto>(branch);

            return new GetBranchResponse
            {
                IsSuccess = true,
                Branch = branchDto
            };
        }
    }
}
