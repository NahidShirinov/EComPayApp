using EComPayApp.Application.DTOs.CategoryDtos;
using EComPayApp.Application.Validators.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Categories
{
    public class GetCategoryDtoValidator : AbstractValidator<GetCategoryDto>
    {
        public GetCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(x => x.Products)
                .NotNull().WithMessage("Products collection cannot be null.")
                .ForEach(product => product.SetValidator(new GetProductDtoValidator())); 
        }
    }
}
