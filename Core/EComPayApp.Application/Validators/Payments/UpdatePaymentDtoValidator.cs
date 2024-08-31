using EComPayApp.Application.DTOs.PaymentDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Payments
{
    public class UpdatePaymentDtoValidator : AbstractValidator<UpdatePaymentDto>
    {
        public UpdatePaymentDtoValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).When(x => x.Amount > 0)
                .WithMessage("Amount must be greater than zero.");

            RuleFor(x => x.PaymentMethod)
                .Length(1, 50).When(x => !string.IsNullOrEmpty(x.PaymentMethod))
                .WithMessage("PaymentMethod must be between 1 and 50 characters.");
        }
    }

}
