using AutoMapper;
using EComPayApp.Application.DTOs.ImageDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, GetImageDto>().ReverseMap();
        }
    }
}
