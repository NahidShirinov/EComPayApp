using EComPayApp.Application.DTOs.PaymentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Payments
{
    public class GetPaymentDtoValidator : AbstractValidator<GetPaymentDto>
    {
        public GetPaymentDtoValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("PaymentMethod is required.")
                .Length(1, 50).WithMessage("PaymentMethod must be between 1 and 50 characters.");
        }
    }

}
