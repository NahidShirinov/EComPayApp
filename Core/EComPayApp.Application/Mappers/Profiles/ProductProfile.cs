using AutoMapper;
using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductDto>().ReverseMap();
        }
    }
}
