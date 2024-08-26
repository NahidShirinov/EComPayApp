using EComPayApp.Application.Features.CQRS.Commands.OrderItems.UpdateOrderItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest<DeleteOrderItemResponse>
    {
        public Guid Id { get; set; }
    }
}

