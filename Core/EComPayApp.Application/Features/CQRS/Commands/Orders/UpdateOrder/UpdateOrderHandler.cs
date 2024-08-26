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

namespace EComPayApp.Application.Features.CQRS.Commands.Orders.UpdateImage
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.WriteRepository<Order>().GetByIdAsync(request.Id);
            if (order == null)
            {
                return new UpdateOrderResponse
                {
                    IsSuccess = false,
                    Message = "Order not found"
                };
            }

            _mapper.Map(request, order);
            await _unitOfWork.CommitAsync();

            return new UpdateOrderResponse
            {
                IsSuccess = true,
                Message = "Order updated successfully",
                Order = _mapper.Map<GetOrderDto>(order)
            };
        }
    
    }
}
