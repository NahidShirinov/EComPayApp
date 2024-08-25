using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
