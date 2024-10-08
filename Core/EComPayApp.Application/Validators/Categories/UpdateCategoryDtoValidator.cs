﻿using EComPayApp.Application.DTOs.CategoryDtos;
using EComPayApp.Application.Validators.Products;
using FluentValidation;

namespace EComPayApp.Application.Validators.Categories
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(x => x.Products)
                .NotNull().WithMessage("Products collection cannot be null.")
                .Must(products => products.Count > 0).WithMessage("At least one product is required.")
                .ForEach(product => product.SetValidator(new GetProductDtoValidator())); 
        }
    }
}
