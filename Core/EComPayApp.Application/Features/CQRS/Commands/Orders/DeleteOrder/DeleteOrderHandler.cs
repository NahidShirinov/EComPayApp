using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Orders.DeleteImage
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.WriteRepository<Order>().GetByIdAsync(request.Id);
            if (order == null)
            {
                return new DeleteOrderResponse
                {
                    IsSuccess = false,
                    Message = "Order not found"
                };
            }

            _unitOfWork.WriteRepository<Order>().DeleteAsync(order);
            await _unitOfWork.CommitAsync();

            return new DeleteOrderResponse
            {
                IsSuccess = true,
                Message = "Order deleted successfully"
            };
        }
    
    }
}
