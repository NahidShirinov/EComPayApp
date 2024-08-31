using EComPayApp.Application.DTOs.OrderDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Orders
{
    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(x => x.Description)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Address)
                .Length(10, 200).When(x => !string.IsNullOrEmpty(x.Address))
                .WithMessage("Address must be between 10 and 200 characters.");

            RuleFor(x => x.Status)
                .IsInEnum().When(x => x.Status != default)
                .WithMessage("Invalid status value.");
        }
    }

}
