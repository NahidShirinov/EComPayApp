using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.UpdateContact
{
    public class UpdateContactResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
