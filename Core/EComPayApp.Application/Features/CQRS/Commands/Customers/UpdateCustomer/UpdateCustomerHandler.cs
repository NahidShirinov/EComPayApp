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

namespace EComPayApp.Application.Features.CQRS.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse>
    {
        private readonly IWriteRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(IWriteRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return new UpdateCustomerResponse
                {
                    IsSuccess = false,
                    Message = "Customer not found"
                };
            }

            _mapper.Map(request, customer);

            var result = _repository.Update(customer);
            await _repository.SaveAsync();

            return new UpdateCustomerResponse
            {
                IsSuccess = true,
                Message = "Customer updated successfully",
                Customer = _mapper.Map<GetCustomerDto>(customer)
            };
        }
    }
}