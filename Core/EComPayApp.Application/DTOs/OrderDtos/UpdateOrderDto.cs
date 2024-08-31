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
    public class UpdateOrderDto:IDto
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal? Discount { get; set; }
        public OrderStatus Status { get; set; }
        public List<UpdateOrderItemDto> OrderItems { get; set; } = new List<UpdateOrderItemDto>();
        public List<UpdatePaymentDto> Payments { get; set; } = new List<UpdatePaymentDto>();
    }
}
