using AutoMapper;
using EComPayApp.Application.DTOs.OrderItems;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.UpdateOrderItem
{
    public class UpdateOrderItemHandler : IRequestHandler<UpdateOrderItemCommand, UpdateOrderItemResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOrderItemResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _unitOfWork.WriteRepository<OrderItem>().GetByIdAsync(request.Id);
            if (orderItem == null)
            {
                return new UpdateOrderItemResponse
                {
                    IsSuccess = false,
                    Message = "Order item not found"
                };
            }

            orderItem.Quantity = request.Quantity;
            await _unitOfWork.CommitAsync();

            return new UpdateOrderItemResponse
            {
                IsSuccess = true,
                Message = "Order item updated successfully",
                OrderItem = _mapper.Map<GetOrderItemsDto>(orderItem)
            };
        }
    
    }
}
