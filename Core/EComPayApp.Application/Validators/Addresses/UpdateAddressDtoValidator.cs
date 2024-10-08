﻿using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.Validators.Branches;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Addresses
{
    public class UpdateAddressValidator : AbstractValidator<UpdateAddressDto>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
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
            RuleFor(x => x.Branches)
                .NotNull().WithMessage("Branches collection cannot be null.")
                .Must(branches => branches.Count > 0).WithMessage("At least one branch is required.")
                .ForEach(branch => branch.SetValidator(new GetBranchDtoValidator()));
        }
    }

}
