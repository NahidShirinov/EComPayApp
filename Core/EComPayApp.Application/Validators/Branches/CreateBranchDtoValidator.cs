using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Branches
{
    using EComPayApp.Application.DTOs.BranchDtos;
    using FluentValidation;

    public class CreateBranchDtoValidator : AbstractValidator<CreateBranchDto>
    {
        public CreateBranchDtoValidator()
        {
            RuleFor(x => x.AddressId)
                .NotEmpty().WithMessage("AddressId is required.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address cannot be null.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

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
                .Must(products => products.Count > 0).WithMessage("At least one product is required.")
                .ForEach(product => product.SetValidator(new GetProductDtoValidator())); // Assumes GetProductDto has its own validator
        }
    }
}
