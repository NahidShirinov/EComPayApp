﻿using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.Validators.Branches;
using FluentValidation;

namespace EComPayApp.Application.Validators.Addresses
{
    public class CreateAddressDtoValidator : AbstractValidator<CreateAddressDto>
    {
        public CreateAddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .Length(1, 100).WithMessage("Street must be between 1 and 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(1, 50).WithMessage("City must be between 1 and 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State is required.")
                .Length(1, 50).WithMessage("State must be between 1 and 50 characters.");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("ZipCode is required.")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("ZipCode must be in the format 12345 or 12345-6789.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .Length(1, 50).WithMessage("Country must be between 1 and 50 characters.");
        }
    }

}
