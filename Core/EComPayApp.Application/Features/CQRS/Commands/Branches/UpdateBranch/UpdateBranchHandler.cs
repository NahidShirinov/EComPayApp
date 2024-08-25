using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Products.UpdateProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Branches.UpdateBranch
{
    public class UpdateBranchHandler:IRequestHandler<UpdateBranchCommand,UpdateBranchResponse>
    {
        private readonly IWriteRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public UpdateBranchHandler(IWriteRepository<Branch> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateBranchResponse> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id);

            if (branch == null)
            {
                return new UpdateBranchResponse
                {
                    IsSuccess = false,
                    Message = "Branch not found"
                };
            }

            _mapper.Map(request, branch);

            var result = _repository.Update(branch);
            await _repository.SaveAsync();

            return new UpdateBranchResponse
            {
                IsSuccess = result,
                Message = result ? "Branch updated successfully" : "Update failed"
            };
        }
    }
}
