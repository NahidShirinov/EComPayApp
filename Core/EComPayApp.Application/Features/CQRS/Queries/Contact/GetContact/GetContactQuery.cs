using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Contact.GetContact
{
    public class GetContactQuery : IRequest<GetContactResponse>
    {
        public Guid Id { get; set; }

       
    }
}
