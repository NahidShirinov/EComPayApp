using EComPayApp.Application.Exceptions;
using EComPayApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        //Usermanager --istifadecile bagli temel isleri gormek ucun istifade edilir..,SignInManager Istifadeciniin giris verilenleri ucun istifde edilir
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if(user==null)
                user=await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null)
                throw new NotFoundUserException("Istifadeci adi ve ya shifre yalnishdir");

          SignInResult result=await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
            if (result.Succeeded)
            {
                //Auth ugurlduur.
            }
                return new();
        }
    }
}
