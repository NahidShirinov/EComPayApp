using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.OrderItems.GetOrderItem
{
    public class GetOrderItemQuery : IRequest<GetOrderItemResponse>
    {
        public Guid Id { get; set; }
    }
    
    }

