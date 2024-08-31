using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.Validators.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Customers
{
    public class GetCustomerDtoValidator : AbstractValidator<GetCustomerDto>
    {
        public GetCustomerDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .Length(1, 50).WithMessage("FirstName must be between 1 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .Length(1, 50).WithMessage("LastName must be between 1 and 50 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Orders)
                .NotNull().WithMessage("Orders collection cannot be null.")
                .ForEach(order => order.SetValidator(new GetOrderDtoValidator())); 
        }
    }
}
