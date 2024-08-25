using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.DTOs.ProductDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerResponse>
    {
        public Guid Id { get; set; }
    }


}
