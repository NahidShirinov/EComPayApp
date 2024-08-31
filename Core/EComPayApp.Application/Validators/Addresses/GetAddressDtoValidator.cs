using EComPayApp.Application.DTOs.AddressDtos;
using FluentValidation;

namespace EComPayApp.Application.Validators.Addresses
{
    public class GetAddressDtoValidator : AbstractValidator<GetAddressDto>
    {
        public GetAddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .Length(5, 100).WithMessage("Street must be between 5 and 100 characters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(2, 50).WithMessage("City must be between 2 and 50 characters.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State is required.")
                .Length(2, 50).WithMessage("State must be between 2 and 50 characters.");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("ZipCode is required.")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("ZipCode must be in a valid format (e.g., 12345 or 12345-6789).");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .Length(2, 50).WithMessage("Country must be between 2 and 50 characters.");
        }
    }
}
