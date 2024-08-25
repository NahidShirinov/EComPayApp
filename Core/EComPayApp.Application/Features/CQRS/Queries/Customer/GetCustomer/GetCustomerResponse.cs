using EComPayApp.Application.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer
{
    public class GetCustomerResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetCustomerDto Customer { get; set; }
    }
}
