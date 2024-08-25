using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Products.CreateProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Branches.CreateBranch
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResponse>
    {
        private readonly IWriteRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public CreateBranchHandler(IWriteRepository<Branch> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateBranchResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _mapper.Map<Branch>(request);

            var result = await _repository.AddAsync(branch);
            await _repository.SaveAsync();

            return new CreateBranchResponse
            {
                IsSuccess = result,
                Message = result ? "Branch created successfully" : "Creation failed"
            };
        }
    }
}
