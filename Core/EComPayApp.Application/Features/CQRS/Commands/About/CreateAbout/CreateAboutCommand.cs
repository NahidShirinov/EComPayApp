using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.About.CreateAbout
{
    public class CreateAboutCommand : IRequest<CreateAboutResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
    }
    
    }

