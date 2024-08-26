using EComPayApp.Application.DTOs.OrderDtos;
using EComPayApp.Application.DTOs.PaymentDtos;
using EComPayApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal? Discount { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<GetOrderDto> OrderItems { get; set; }
        public ICollection<GetPaymentDto> Payments { get; set; }
    }
}
