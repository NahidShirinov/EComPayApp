using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.DeleteOrderItem
{
    public class DeleteOrderItemHandler : IRequestHandler<DeleteOrderItemCommand, DeleteOrderItemResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteOrderItemResponse> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _unitOfWork.WriteRepository<OrderItem>().GetByIdAsync(request.Id);
            if (orderItem == null)
            {
                return new DeleteOrderItemResponse
                {
                    IsSuccess = false,
                    Message = "Order item not found"
                };
            }

            _unitOfWork.WriteRepository<OrderItem>().DeleteAsync(orderItem);
            await _unitOfWork.CommitAsync();

            return new DeleteOrderItemResponse
            {
                IsSuccess = true,
                Message = "Order item deleted successfully"
            };
        }
    
    }
}
