using EComPayApp.Application.DTOs.FacebookDtos;
using EComPayApp.Application.DTOs.Token;
using EComPayApp.Application.Interfaces.Token;
using EComPayApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.FacebookLogin
{
    public class FacebookLoginHandler : IRequestHandler<FacebookLoginCommand, FacebookLoginResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly HttpClient _httpClient;

        public FacebookLoginHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<FacebookLoginResponse> Handle(FacebookLoginCommand request, CancellationToken cancellationToken)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id=906332564881246&client_secret=0373ada3fb13d15d1109644cb06b9ea9&grant_type=client_credentials");
            FacebookAccessTokenResponseDto facebookAccessTokenResponseDto =
               JsonSerializer.Deserialize<FacebookAccessTokenResponseDto>(accessTokenResponse);
            string userAccessTokenValidation = await _httpClient.GetStringAsync($"\"https://graph.facebook.com/debug_token?input_token={request.AuthToken}&access_token={facebookAccessTokenResponseDto.AccessToken}");
            FacebookUserAccessTokenValidationDto validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidationDto>(userAccessTokenValidation);
            if (validation.Data.IsValid)
            {
                string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token{request.AuthToken}");
                FacebookUserInfoResponseDto infoResponseDto = JsonSerializer.Deserialize<FacebookUserInfoResponseDto>(userInfoResponse);
                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                bool result = user != null;
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(infoResponseDto.Email);
                    if (user == null)
                    {
                        user = new()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = infoResponseDto.Email,
                            UserName = infoResponseDto.Email,
                            NameSurname = infoResponseDto.Name,

                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        result = identityResult.Succeeded;

                    }
                }
                if (result)
                {
                    await _userManager.AddLoginAsync(user, info);
                    Token token = _tokenHandler.CreateAccessToken(5);
                    return new()
                    {
                        Token = token
                    };
                }


            }
            throw new Exception("Invalid external authentication.");
        }
    }
}
