using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Order.GetOrder
{
    public class GetOrderQuery : IRequest<GetOrderResponse>
    {
        public Guid Id { get; set; }
    
    
    }
}
