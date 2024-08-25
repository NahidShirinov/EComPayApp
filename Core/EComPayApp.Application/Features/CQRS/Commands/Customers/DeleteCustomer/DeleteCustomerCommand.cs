using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }

    }
}
