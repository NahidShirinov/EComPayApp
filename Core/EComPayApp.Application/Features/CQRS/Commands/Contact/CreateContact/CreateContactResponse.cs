using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.CreateContact
{
    public class CreateContactResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Guid ContactId { get; set; }
    }
}
