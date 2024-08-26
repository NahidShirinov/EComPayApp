using AutoMapper;
using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress
{
    public class GetAddressHandler : IRequestHandler<GetAddressQuery, GetAddressResponse>
    {
        private readonly IReadRepository<EComPayApp.Domain.Entities.Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressHandler(IReadRepository<EComPayApp.Domain.Entities.Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAddressResponse> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(request.Id);

            if (address == null)
            {
                return new GetAddressResponse
                {
                    IsSuccess = false,
                    Message = "Address not found"
                };
            }

            var addressDto = _mapper.Map<GetAddressDto>(address);

            return new GetAddressResponse
            {
                IsSuccess = true,
                Message = "Customer retrieved successfully",
                Address = _mapper.Map<GetAddressDto>(address)
            };
        }
    }
}
