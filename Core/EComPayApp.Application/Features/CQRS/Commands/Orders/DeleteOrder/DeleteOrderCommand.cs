using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Orders.DeleteImage
{
    public class DeleteOrderCommand : IRequest<DeleteOrderResponse>
    {
        public Guid Id { get; set; }
    
    }
}
