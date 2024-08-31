using EComPayApp.Application.DTOs.ContactDtos;
using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Contact.GetContact
{
    public class GetContactHandler : IRequestHandler<GetContactQuery, GetContactResponse>
    {
        private readonly IReadRepository<EComPayApp.Domain.Entities.Contact> _contactRepository;

        public GetContactHandler(IReadRepository<EComPayApp.Domain.Entities.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<GetContactResponse> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == null)
            {
                return new GetContactResponse
                {
                    IsSuccess = false,
                    Message = "Contact not found"
                };
            }

            var contactDto = new GetContactDto
            {
                Id = contact.Id,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Address = contact.Address,
                MapLocation = contact.MapLocation
            };

            return new GetContactResponse
            {
                IsSuccess = true,
                Contact = contactDto
            };
        }
    
    }
}
