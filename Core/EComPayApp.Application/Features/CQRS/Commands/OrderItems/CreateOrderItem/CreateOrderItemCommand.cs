using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<CreateOrderItemResponse>
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    
    }
}
