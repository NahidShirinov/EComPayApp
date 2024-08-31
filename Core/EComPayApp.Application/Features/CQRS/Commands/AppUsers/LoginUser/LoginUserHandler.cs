using EComPayApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        //Usermanager --istifadecile bagli temel isleri gormek ucun istifade edilir..,SignInManager Istifadeciniin giris verilenleri ucun istifde edilir
        readonly UserManager<AppUser> userManager;
        readonly SignInManager<AppUser> _signInManager;
        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await userManager.FindByNameAsync(request.UsernameOrEmail);
            return null;    
        }
    }
}
