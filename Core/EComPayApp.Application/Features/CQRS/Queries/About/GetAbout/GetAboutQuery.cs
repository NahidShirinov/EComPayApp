using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.About.GetAbout
{
    public class GetAboutQuery : IRequest<GetAboutResponse>
    {
        public Guid Id { get; set; }

       
    }
    
    }

