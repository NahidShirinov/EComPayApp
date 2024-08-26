using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.UpdatePayment
{
    public class UpdatePaymentCommand:IRequest<UpdatePaymentResponse>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool Status { get; set; }
    }
}
