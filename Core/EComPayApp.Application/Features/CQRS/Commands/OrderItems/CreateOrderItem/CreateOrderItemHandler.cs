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

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.CreateOrderItem
{
    public class CreateOrderItemHandler : IRequestHandler<CreateOrderItemCommand, CreateOrderItemResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOrderItemResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ReadRepository<Product>().GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return new CreateOrderItemResponse
                {
                    IsSuccess = false,
                    Message = "Product not found"
                };
            }

            var orderItem = new OrderItem
            {
                ProductId = request.ProductId,
                OrderId = request.OrderId,
                Quantity = request.Quantity,
                Product = product
            };

            await _unitOfWork.WriteRepository<OrderItem>().AddAsync(orderItem);
            await _unitOfWork.CommitAsync();

            return new CreateOrderItemResponse
            {
                IsSuccess = true,
                Message = "Order item created successfully",
                OrderItem = _mapper.Map<GetOrderItemDto>(orderItem)
            };
        }
    }
}
