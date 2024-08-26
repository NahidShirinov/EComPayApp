using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.OrderItems.UpdateOrderItem
{
    public class UpdateOrderItemCommand : IRequest<UpdateOrderItemResponse>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
    
    }

