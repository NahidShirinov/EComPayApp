using AutoMapper;
using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.UpdateAddress
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressHandler(IWriteRepository<EComPayApp.Domain.Entities.Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            // `Address` entitisini al və `request` məlumatları ilə güncəllə
            var address = await _repository.GetByIdAsync(request.Id);

            if (address == null)
            {
                return new UpdateAddressResponse
                {
                    IsSuccess = false,
                    Message = "Address not found"
                };
            }

            _mapper.Map(request, address); // Mapping request to existing Address

            var result = _repository.Update(address);
            await _repository.SaveAsync();

            return new UpdateAddressResponse
            {
                IsSuccess = result,
                Message = result ? "Address updated successfully" : "Update failed"
            };
        }
    
    }
}
