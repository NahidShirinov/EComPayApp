using EComPayApp.Application.DTOs.PaymentDtos;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.UpdatePayment
{
    public class UpdatePaymentResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetPaymentDto Payment { get; set; }

    }
}
