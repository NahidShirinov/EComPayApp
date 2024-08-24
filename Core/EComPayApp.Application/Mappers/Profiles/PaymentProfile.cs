using AutoMapper;
using EComPayApp.Application.DTOs.PaymentDtos;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, GetPaymentDto>().ReverseMap();
        }
    }

}
