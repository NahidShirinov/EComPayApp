using EComPayApp.Application.DTOs.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Products
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .Length(2, 100).When(x => !string.IsNullOrEmpty(x.Name))
                .WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(x => x.Code)
                .Length(2, 50).When(x => !string.IsNullOrEmpty(x.Code))
                .WithMessage("Code must be between 2 and 50 characters.");

            RuleFor(x => x.Description)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Stock)
                .GreaterThan(0).When(x => x.Stock > 0)
                .WithMessage("Stock must be greater than zero.");

            RuleFor(x => x.Price)
                .GreaterThan(0).When(x => x.Price > 0)
                .WithMessage("Price must be greater than zero.");
        }
    }

}
