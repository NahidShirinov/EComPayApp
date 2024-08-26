using AutoMapper;
using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.CreateAddress
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, CreateAddressResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.Address> _repository;
        private readonly IMapper _mapper;

        public CreateAddressHandler(IWriteRepository<EComPayApp.Domain.Entities.Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            // DTO-dan Address entitisini yarat
            var address = _mapper.Map<EComPayApp.Domain.Entities.Address>(request);

            // Repository vasitəsilə Address-i əlavə et
            var result = await _repository.AddAsync(address);

            // Cavab üçün DTO yaradın
            var response = new CreateAddressResponse
            {
                IsSuccess = true,
                Message = "Address created successfully",
                Address = _mapper.Map<GetAddressDto>(address)
            };

            return response;
        }
    
    }
}
