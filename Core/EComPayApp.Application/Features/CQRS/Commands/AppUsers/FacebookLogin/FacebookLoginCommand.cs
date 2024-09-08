using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.FacebookLogin
{
    public class FacebookLoginCommand:IRequest<FacebookLoginResponse>
    {
        public string AuthToken { get; set; }
    }
}
