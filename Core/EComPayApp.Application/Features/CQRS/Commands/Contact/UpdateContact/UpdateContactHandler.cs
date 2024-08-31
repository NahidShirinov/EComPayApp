using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.UpdateContact
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, UpdateContactResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.Contact> _contactRepository;

        public UpdateContactHandler(IWriteRepository<EComPayApp.Domain.Entities.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<UpdateContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == null)
            {
                return new UpdateContactResponse
                {
                    IsSuccess = false,
                    Message = "Contact not found"
                };
            }

            contact.PhoneNumber = request.Phone;
            contact.Email = request.Email;
            contact.Address = request.Address;
            contact.MapLocation = request.MapLocation;

            await _contactRepository.UpdateAsync(contact);

            return new UpdateContactResponse
            {
                IsSuccess = true,
                Message = "Contact updated successfully"
            };
        }
    
    }
}
