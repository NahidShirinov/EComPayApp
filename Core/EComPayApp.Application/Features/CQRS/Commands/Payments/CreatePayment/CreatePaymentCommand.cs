using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.CreatePayment
{
    public class CreatePaymentCommand:IRequest<CreatePaymentResponse>
    {
        public Guid OrderId { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
    }
}
