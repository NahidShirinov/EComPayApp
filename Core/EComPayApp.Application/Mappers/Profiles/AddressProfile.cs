using AutoMapper;
using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, GetAddressDto>().ReverseMap();
        }
    }
}
