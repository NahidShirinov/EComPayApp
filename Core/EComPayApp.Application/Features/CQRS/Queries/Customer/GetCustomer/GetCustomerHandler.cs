using AutoMapper;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, GetCustomerResponse>
    {
        private readonly IReadRepository<EComPayApp.Domain.Entities.Address> _repository;
        private readonly IMapper _mapper;

        public GetCustomerHandler(IReadRepository<EComPayApp.Domain.Entities.Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return new GetCustomerResponse
                {
                    IsSuccess = false,
                    Message = "Customer not found"
                };
            }

            var customerDto = _mapper.Map<GetCustomerDto>(customer);

            return new GetCustomerResponse
            {
                IsSuccess = true,
                Message = "Customer retrieved successfully",
                Customer = _mapper.Map<GetCustomerDto>(customer)

            };
        }
    }
    }