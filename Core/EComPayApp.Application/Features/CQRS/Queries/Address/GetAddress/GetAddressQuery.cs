using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress
{
    public class GetAddressQuery : IRequest<GetAddressResponse>
    {
        public Guid Id { get; set; }
       
    }
}
