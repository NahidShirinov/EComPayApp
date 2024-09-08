using EComPayApp.Application.DTOs.Token;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.FacebookLogin
{
    public class FacebookLoginResponse
    {
        public Token Token { get; set; }
    }
}
