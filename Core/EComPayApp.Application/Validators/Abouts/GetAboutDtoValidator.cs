using EComPayApp.Application.DTOs.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Abouts
{
    public class GetAboutDtoValidator : AbstractValidator<GetAboutDto>
    {
        public GetAboutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

            RuleFor(x => x.Description)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Vision)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Vision))
                .WithMessage("Vision must be between 10 and 500 characters.");

            RuleFor(x => x.Mission)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Mission))
                .WithMessage("Mission must be between 10 and 500 characters.");
        }
    }
}
