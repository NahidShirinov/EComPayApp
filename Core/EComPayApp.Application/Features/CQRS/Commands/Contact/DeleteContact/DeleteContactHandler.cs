using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.DeleteContact
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, DeleteContactResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.Contact> _contactRepository;

        public DeleteContactHandler(IWriteRepository<EComPayApp.Domain.Entities.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<DeleteContactResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == null)
            {
                return new DeleteContactResponse
                {
                    IsSuccess = false,
                    Message = "Contact not found"
                };
            }

            await _contactRepository.DeleteAsync(contact);

            return new DeleteContactResponse
            {
                IsSuccess = true,
                Message = "Contact deleted successfully"
            };
        }
    
    }
}
