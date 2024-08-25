using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<DeleteAddressResponse>
    {
        public Guid Id { get; set; }
    
    }
}
