using AutoMapper;
using EComPayApp.Application.DTOs.OrderDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, GetOrderDto>().ReverseMap();
        }
    }

}
