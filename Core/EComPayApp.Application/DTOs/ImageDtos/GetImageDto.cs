using EComPayApp.Application.Interfaces.DTO;
using EComPayApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.DTOs.ImageDtos
{
    public class GetImageDto:IDto
    {
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
        public Product Product { get; set; }
    }
}
