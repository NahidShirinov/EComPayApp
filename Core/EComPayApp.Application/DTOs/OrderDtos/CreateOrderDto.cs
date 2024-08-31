using EComPayApp.Application.DTOs.OrderItems;
using EComPayApp.Application.DTOs.PaymentDtos;
using EComPayApp.Application.Interfaces.DTO;
using EComPayApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.DTOs.OrderDtos
{
    public class CreateOrderDto:IDto
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal? Discount { get; set; }
        public OrderStatus Status { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
        public List<CreatePaymentDto> Payments { get; set; } = new List<CreatePaymentDto>();
    }
}
