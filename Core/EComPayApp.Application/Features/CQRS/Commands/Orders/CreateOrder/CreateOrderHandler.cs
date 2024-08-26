using AutoMapper;
using EComPayApp.Application.DTOs.OrderDtos;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            await _unitOfWork.WriteRepository<Order>().AddAsync(order);
            await _unitOfWork.CommitAsync();

            var response = new CreateOrderResponse
            {
                IsSuccess = true,
                Message = "Order created successfully",
                Order = _mapper.Map<GetOrderDto>(order)
            };

            return response;
        }
    
    }
}
