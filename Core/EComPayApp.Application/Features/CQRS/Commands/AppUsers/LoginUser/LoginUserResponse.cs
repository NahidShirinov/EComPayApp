﻿using EComPayApp.Application.DTOs.Token;

namespace EComPayApp.Application.Features.CQRS.Commands.AppUsers.LoginUser
{
    public class LoginUserResponse
    {
        public Token Token { get; set; }
    }
}
