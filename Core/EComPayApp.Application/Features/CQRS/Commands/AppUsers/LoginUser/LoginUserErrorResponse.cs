using EComPayApp.Application.DTOs.Token;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.LoginUser
{
    public class LoginUserErrorResponse:LoginUserResponse
    {
        public string Message { get; set; }
    }
}
