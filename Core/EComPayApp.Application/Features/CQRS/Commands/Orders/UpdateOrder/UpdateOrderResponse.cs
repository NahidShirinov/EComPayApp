using EComPayApp.Application.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Orders.UpdateImage
{
    public class UpdateOrderResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetOrderDto Order { get; set; }
    }
}
