using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.DeleteAddress
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.Address> _repository;

        public DeleteAddressHandler(IWriteRepository<EComPayApp.Domain.Entities.Address> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteAddressResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(request.Id);

            if (address == null)
            {
                return new DeleteAddressResponse
                {
                    IsSuccess = false,
                    Message = "Address not found"
                };
            }

            var result = _repository.Remove(address);
            await _repository.SaveAsync();

            return new DeleteAddressResponse
            {
                IsSuccess = result,
                Message = result ? "Address deleted successfully" : "Delete failed"
            };
        }
    
    }
}
