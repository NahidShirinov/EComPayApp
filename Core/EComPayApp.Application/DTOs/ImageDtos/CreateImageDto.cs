using EComPayApp.Application.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.DTOs.ImageDtos
{
    public class CreateImageDto:IDto
    {
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
    }
}
