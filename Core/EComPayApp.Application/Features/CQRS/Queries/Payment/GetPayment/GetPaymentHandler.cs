using AutoMapper;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.DTOs.PaymentDtos;
using EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetPaymentHandler:IRequestHandler<GetPaymentQuery,GetPaymentResponse>
    {
        private readonly IReadRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public GetPaymentHandler(IReadRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetPaymentResponse> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetByIdAsync(request.Id);

            if (payment == null)
            {
                return new GetPaymentResponse
                {
                    IsSuccess = false,
                    Message = "payment not found"
                };
            }

            var paymentDto = _mapper.Map<GetPaymentDto>(payment);

            return new GetPaymentResponse
            {
                IsSuccess = true,
                Payment = paymentDto
            };
        }
    }
}
