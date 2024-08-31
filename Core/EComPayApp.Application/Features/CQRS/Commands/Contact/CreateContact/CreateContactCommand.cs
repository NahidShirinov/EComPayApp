using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.CreateContact
{
    public class CreateContactCommand : IRequest<CreateContactResponse>
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MapLocation { get; set; }
    
    }
}
