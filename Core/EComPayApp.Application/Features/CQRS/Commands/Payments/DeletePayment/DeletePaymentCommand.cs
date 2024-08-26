using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.DeletePayment
{
    public class DeletePaymentCommand:IRequest<DeletePaymentResponse>
    {
        public Guid Id { get; set; }

    }
}
