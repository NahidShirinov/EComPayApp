using EComPayApp.Application.DTOs.ImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.UpdateImage
{
    public class UpdateImageResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetImageDto Image { get; set; }

    }
}
