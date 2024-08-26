using AutoMapper;
using EComPayApp.Application.DTOs.OrderDtos;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Order.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetOrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.ReadRepository<EComPayApp.Domain.Entities.Order>().GetByIdAsync(request.Id);
            if (order == null)
            {
                return new GetOrderResponse
                {
                    IsSuccess = false,
                    Message = "Order not found"
                };
            }

            return new GetOrderResponse
            {
                IsSuccess = true,
                Message = "Order retrieved successfully",
                Order = _mapper.Map<GetOrderDto>(order)
            };
        }
    }
}
