using EComPayApp.Application.DTOs.Token;
using EComPayApp.Application.Interfaces.Token;
using EComPayApp.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.GoogleLogin
{
    public class GoogleLoginHandler : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;

        public GoogleLoginHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler )
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings() {
                Audience=new List<string>() { "179249925455-2a4njdeun4oj9e81ib8jb9q02pa9m8rq.apps.googleusercontent.com" }
            };
            var payload= await GoogleJsonWebSignature.ValidateAsync(request.IdToken,settings);
            var info= new UserLoginInfo(request.Provider,payload.Subject,request.Provider);
           AppUser  user=  await _userManager.FindByLoginAsync(info.LoginProvider,info.ProviderKey);
            bool result=user!=null;
            if (user==null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user==null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name,

                    };
                    var identityResult=await _userManager.CreateAsync(user);
                    result=identityResult.Succeeded;

                }
            }
            if (result)
                await _userManager.AddLoginAsync(user, info);
            else
                throw new Exception("Invalid external authentication.");

            Token token = _tokenHandler.CreateAccessToken(5);
            return new() { Token=token };


        }
    }
}
