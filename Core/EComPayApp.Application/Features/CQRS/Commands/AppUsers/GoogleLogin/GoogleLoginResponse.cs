using EComPayApp.Application.DTOs.Token;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.GoogleLogin
{
    public class GoogleLoginResponse
    {
        public Token Token { get; set; }
    }
}
