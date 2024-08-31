using EComPayApp.Application.DTOs.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Contact.GetContact
{
    public class GetContactResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetContactDto Contact { get; set; }
    }
}
