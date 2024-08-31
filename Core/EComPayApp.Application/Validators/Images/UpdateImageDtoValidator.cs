using EComPayApp.Application.DTOs.ImageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Validators.Images
{
    public class UpdateImageDtoValidator : AbstractValidator<UpdateImageDto>
    {
        public UpdateImageDtoValidator()
        {
            RuleFor(x => x.ImageUrl)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("Invalid URL format.");
        }
    }

}
