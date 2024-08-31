using EComPayApp.Application.DTOs.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Abouts
{
    public class CreateAboutDtoValidator:AbstractValidator<CreateAboutDto>
    {
        public CreateAboutDtoValidator()
        {
            RuleFor(x => x.Title)
             .NotEmpty().WithMessage("Title is required.")
             .Length(2, 100).WithMessage("Title must be between 2 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(10, 500).WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Vision)
                .NotEmpty().WithMessage("Vision is required.")
                .Length(10, 300).WithMessage("Vision must be between 10 and 300 characters.");

            RuleFor(x => x.Mission)
                .NotEmpty().WithMessage("Mission is required.")
                .Length(10, 300).WithMessage("Mission must be between 10 and 300 characters.");
        }
    }
}
