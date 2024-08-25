using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Payments.CreatePayment;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.CreatePayment
{
    public class CreatePaymentHandler:IRequestHandler<CreatePaymentCommand,CreatePaymentResponse>
    {
        private readonly IWriteRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public CreatePaymentHandler(IWriteRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatePaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<Payment>(request);

            var result = await _repository.AddAsync(image);
            await _repository.SaveAsync();

            return new CreatePaymentResponse
            {
                IsSuccess = result,
                Message = result ? "Payment created successfully" : "Creation failed"
            };
        }
    }
}
