using EComPayApp.Application.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.CreateOrderItem
{
    public class CreateOrderItemResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetOrderItemDto OrderItem { get; set; }
    }
}
