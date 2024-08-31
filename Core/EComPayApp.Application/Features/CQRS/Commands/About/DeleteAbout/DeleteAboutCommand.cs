using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.About.DeleteAbout
{
    public class DeleteAboutCommand : IRequest<DeleteAboutResponse>
    {
        public Guid Id { get; set; }

    
    }
}
