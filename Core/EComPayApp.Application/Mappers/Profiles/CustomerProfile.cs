using AutoMapper;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.Features.CQRS.Commands.Customers.CreateCustomer;
using EComPayApp.Domain.Entities;

namespace EComPayApp.Application.Mappers.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            // Mapping between CreateCustomerCommand and Customer
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

            CreateMap<Customer, GetCustomerDto>().ReverseMap();
        }
    }
}
