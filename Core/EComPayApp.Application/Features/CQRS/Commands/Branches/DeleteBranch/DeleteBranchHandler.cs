using EComPayApp.Application.Features.CQRS.Commands.Products.DeleteProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Branches.DeleteBranch
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, DeleteBranchResponse>
    {
        private readonly IWriteRepository<Branch> _repository;

        public DeleteBranchHandler(IWriteRepository<Branch> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteBranchResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id);

            if (branch == null)
            {
                return new DeleteBranchResponse
                {
                    IsSuccess = false,
                    Message = "Branch not found"
                };
            }

            var result = _repository.Remove(branch);
            await _repository.SaveAsync();

            return new DeleteBranchResponse
            {
                IsSuccess = result,
                Message = result ? "Branch deleted successfully" : "Delete failed"
            };
        }
    }
}
