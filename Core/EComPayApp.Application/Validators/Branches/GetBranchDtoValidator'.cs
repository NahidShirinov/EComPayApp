using EComPayApp.Application.DTOs.BranchDtos;
using EComPayApp.Application.Validators.Addresses;
using EComPayApp.Application.Validators.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Branches
{
    public class GetBranchDtoValidator : AbstractValidator<GetBranchDto>
    {
        public GetBranchDtoValidator()
        {
            RuleFor(x => x.AddressId)
                .NotEmpty().WithMessage("AddressId is required.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new GetAddressDtoValidator()); 

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(x => x.Description)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Phone)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => !string.IsNullOrEmpty(x.Phone))
                .WithMessage("Phone number is not in a valid format.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Products)
                .NotNull().WithMessage("Products collection cannot be null.")
                .ForEach(product => product.SetValidator(new GetProductDtoValidator())); 
        }
    }
}
