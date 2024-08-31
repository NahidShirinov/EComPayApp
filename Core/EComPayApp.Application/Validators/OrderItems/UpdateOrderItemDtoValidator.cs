using EComPayApp.Application.DTOs.OrderItems;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.OrderItems
{
    public class UpdateOrderItemDtoValidator : AbstractValidator<UpdateOrderItemDto>
    {
        public UpdateOrderItemDtoValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).When(x => x.Quantity > 0)
                .WithMessage("Quantity must be greater than zero.");
        }
    }

}
