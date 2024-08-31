using EComPayApp.Application.Exceptions;
using EComPayApp.Application.Features.CQRS.Commands.Address.CreateAddress;
using EComPayApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public CreateUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
         IdentityResult result=await _userManager.CreateAsync(new() { 
               Id=Guid.NewGuid().ToString(),
               UserName=request.Username,
               Email=request.Email,
               NameSurname=request.NameSurname,
            },request.Password);
            CreateUserResponse response = new() { IsSuccess=result.Succeeded};
            if (result.Succeeded)
            {
                response.Message = "Istifadechi basharili olushturuldu";
            }
            //throw new UserCreateFailedException();
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code}";
            return response;
        }
    }
}
