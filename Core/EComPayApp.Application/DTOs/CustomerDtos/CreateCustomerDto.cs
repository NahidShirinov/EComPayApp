﻿using EComPayApp.Application.DTOs.OrderDtos;
using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.CustomerDtos
{
    public class CreateCustomerDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<GetOrderDto> Orders { get; set; } = new List<GetOrderDto>();
    }
}
