using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.CreateContact
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, CreateContactResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.Contact> _contactRepository;

        public CreateContactHandler(IWriteRepository<EComPayApp.Domain.Entities.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<CreateContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new EComPayApp.Domain.Entities.Contact
            {
                Id = Guid.NewGuid(),
                PhoneNumber = request.Phone,
                Email = request.Email,
                Address = request.Address,
                MapLocation = request.MapLocation
            };

            await _contactRepository.AddAsync(contact);

            return new CreateContactResponse
            {
                IsSuccess = true,
                ContactId = contact.Id,
                Message = "Contact created successfully"
            };
        }
    
    }
}
