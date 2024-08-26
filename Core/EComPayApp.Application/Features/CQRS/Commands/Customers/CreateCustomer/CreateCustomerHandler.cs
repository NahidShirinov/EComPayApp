using AutoMapper;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Customers.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly IWriteRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(IWriteRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            var result = await _repository.AddAsync(customer);
            await _repository.SaveAsync();

            return new CreateCustomerResponse
            {
                IsSuccess = true,
                Message = "Customer created successfully",
                Customer = _mapper.Map<GetCustomerDto>(customer)
            };
        }
    }
}
