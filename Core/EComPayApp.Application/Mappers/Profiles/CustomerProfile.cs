using AutoMapper;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerDto>().ReverseMap();
        }
    }
}
