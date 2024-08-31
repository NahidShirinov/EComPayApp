using EComPayApp.Application.DTOs.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Products
{
    public class GetProductDtoValidator : AbstractValidator<GetProductDto>
    {
        public GetProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(2, 50).WithMessage("Code must be between 2 and 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(10, 500).WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Stock)
                .GreaterThan(0).WithMessage("Stock must be greater than zero.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("BranchId is required.");
        }
    }

}
