using EComPayApp.Application.DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.About.GetAbout
{
    public class GetAboutResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetAboutDto About { get; set; }
    }
}
