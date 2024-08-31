﻿using EComPayApp.Application.Features.CQRS.Commands.AppUsers.CreateUser;
using EComPayApp.Application.Features.CQRS.Commands.AppUsers.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComPayApp.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand createUserCommand)
        {
            CreateUserResponse response = await _mediator.Send(createUserCommand);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            LoginUserResponse response= await _mediator.Send(loginUserCommand);
            return Ok(response);
        }
    }
}
