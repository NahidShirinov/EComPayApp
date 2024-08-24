using AutoMapper;
using EComPayApp.Application.DTOs.BranchDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, GetBranchDto>().ReverseMap();
        }
    }
}
