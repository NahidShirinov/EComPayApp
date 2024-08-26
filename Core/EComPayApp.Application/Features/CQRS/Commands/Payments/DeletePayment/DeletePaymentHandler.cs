using EComPayApp.Application.Features.CQRS.Commands.Images.DeleteImage;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.DeletePayment
{
    public class DeletePaymentHandler:IRequestHandler<DeletePaymentCommand,DeletePaymentResponse>
    {
        private readonly IWriteRepository<Payment> _repository;

        public DeletePaymentHandler(IWriteRepository<Payment> repository)
        {
            _repository = repository;
        }

        public async Task<DeletePaymentResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetByIdAsync(request.Id);

            if (payment == null)
            {
                return new DeletePaymentResponse
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }

            var result = _repository.Remove(payment);
            await _repository.SaveAsync();

            return new DeletePaymentResponse
            {
                IsSuccess = result,
                Message = result ? "Payment deleted successfully" : "Delete failed"
            };
        }
    }
}
