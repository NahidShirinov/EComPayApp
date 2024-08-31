using EComPayApp.Application.DTOs.OrderItems;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.OrderItems
{
    public class GetOrderItemDtoValidator : AbstractValidator<GetOrderItemDto>
    {
        public GetOrderItemDtoValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }

}
