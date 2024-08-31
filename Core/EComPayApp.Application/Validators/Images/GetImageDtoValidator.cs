using EComPayApp.Application.DTOs.ImageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Images
{
    public class GetImageDtoValidator : AbstractValidator<GetImageDto>
    {
        public GetImageDtoValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Invalid URL format.");

            RuleFor(x => x.IsMainImage)
                .NotNull().WithMessage("IsMainImage is required.");
        }
    }

}
