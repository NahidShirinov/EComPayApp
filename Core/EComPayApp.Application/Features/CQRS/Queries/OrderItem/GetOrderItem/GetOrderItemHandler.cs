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

namespace EComPayApp.Application.Features.CQRS.Queries.OrderItems.GetOrderItem
{
    public class GetOrderItemHandler : IRequestHandler<GetOrderItemQuery, GetOrderItemResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetOrderItemResponse> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _unitOfWork.ReadRepository<OrderItem>().GetByIdAsync(request.OrderItemId);
            if (orderItem == null)
            {
                return new GetOrderItemResponse
                {
                    IsSuccess = false,
                    Message = "Order item not found"
                };
            }

            return new GetOrderItemResponse
            {
                IsSuccess = true,
                Message = "Order item retrieved successfully",
                OrderItem = _mapper.Map<GetOrderItemsDto>(orderItem)
            };
        }
    
    }
}
