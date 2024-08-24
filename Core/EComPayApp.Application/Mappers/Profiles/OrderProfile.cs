using AutoMapper;
using EComPayApp.Application.DTOs.OrderDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, GetOrderDto>().ReverseMap();
        }
    }
}
