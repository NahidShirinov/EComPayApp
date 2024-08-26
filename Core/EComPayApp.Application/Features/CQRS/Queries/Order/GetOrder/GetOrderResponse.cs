using EComPayApp.Application.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Order.GetOrder
{
    public class GetOrderResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetOrderDto Order { get; set; }
    }
}
