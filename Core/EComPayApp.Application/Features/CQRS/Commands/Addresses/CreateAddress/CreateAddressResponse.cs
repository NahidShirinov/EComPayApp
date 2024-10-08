﻿using EComPayApp.Application.DTOs.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.CreateAddress
{
    public class CreateAddressResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetAddressDto Address { get; set; }
    }
}
