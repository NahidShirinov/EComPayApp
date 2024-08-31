using EComPayApp.Application.DTOs.Token;
using EComPayApp.Application.Exceptions;
using EComPayApp.Application.Interfaces.Token;
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
        readonly ITokenHandler _tokenHandler;
        public LoginUserHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if(user==null)
                user=await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null)
                throw new NotFoundUserException();

          SignInResult result=await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(15);
                return new LoginUserSuccessResponse() { Token=token };
            }
            throw new AuthenticationErrorException();
        }
    }
}
