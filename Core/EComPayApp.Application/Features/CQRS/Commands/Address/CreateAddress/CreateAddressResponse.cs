using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.CreateAddress
{
    public class CreateAddressResponse
    {
        public Guid Id { get; internal set; }
        public bool IsSuccess { get; internal set; }
    }
}
