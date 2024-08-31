using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.About.CreateAbout
{
    public class CreateAboutResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Guid AboutId { get; set; }
    }
}
