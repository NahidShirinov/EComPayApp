using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly IWriteRepository<Customer> _repository;

        public DeleteCustomerHandler(IWriteRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return new DeleteCustomerResponse
                {
                    IsSuccess = false,
                    Message = "Customer not found"
                };
            }

            var result = _repository.Remove(customer);
            await _repository.SaveAsync();

            return new DeleteCustomerResponse
            {
                IsSuccess = result,
                Message = result ? "Customer deleted successfully" : "Delete failed"
            };
        }
    }
}
