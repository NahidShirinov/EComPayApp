using EComPayApp.Application.DTOs.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Contacts
{
    public class GetContactDtoValidator : AbstractValidator<GetContactDto>
    {
        public GetContactDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 250).WithMessage("Address must be between 5 and 250 characters.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Phone number is not in a valid format.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.WorkingHours)
                .Length(5, 100).When(x => !string.IsNullOrEmpty(x.WorkingHours))
                .WithMessage("WorkingHours must be between 5 and 100 characters.");

            RuleFor(x => x.MapLocation)
                .Length(5, 200).When(x => !string.IsNullOrEmpty(x.MapLocation))
                .WithMessage("MapLocation must be between 5 and 200 characters.");
        }
    }
}
