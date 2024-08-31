using EComPayApp.Application.DTOs.AboutDtos;
using FluentValidation;

namespace EComPayApp.Application.Validators.Abouts
{
    public class UpdateAboutDtoValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.Title)
                .Length(2, 100).When(x => !string.IsNullOrEmpty(x.Title))
                .WithMessage("Title must be between 2 and 100 characters.");

            RuleFor(x => x.Description)
                .Length(10, 500).When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description must be between 10 and 500 characters.");

            RuleFor(x => x.Vision)
                .Length(10, 300).When(x => !string.IsNullOrEmpty(x.Vision))
                .WithMessage("Vision must be between 10 and 300 characters.");

            RuleFor(x => x.Mission)
                .Length(10, 300).When(x => !string.IsNullOrEmpty(x.Mission))
                .WithMessage("Mission must be between 10 and 300 characters.");
        }
    }
}
