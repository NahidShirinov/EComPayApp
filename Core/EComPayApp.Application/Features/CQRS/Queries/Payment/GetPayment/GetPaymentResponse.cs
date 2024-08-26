using EComPayApp.Application.DTOs.PaymentDtos;
using EComPayApp.Application.DTOs.ProductDtos;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetPaymentResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetPaymentDto Payment { get; set; }
    }
}
