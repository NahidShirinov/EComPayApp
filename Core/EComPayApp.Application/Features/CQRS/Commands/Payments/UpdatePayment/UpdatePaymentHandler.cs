using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Images.UpdateImage;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Payments.UpdatePayment
{
    public class UpdatePaymentHandler:IRequestHandler<UpdatePaymentCommand,UpdatePaymentResponse>
    {
        private readonly IWriteRepository<Payment> _repository;
        private readonly IMapper _mapper;

        public UpdatePaymentHandler(IWriteRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdatePaymentResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _repository.GetByIdAsync(request.Id);

            if (payment == null)
            {
                return new UpdatePaymentResponse
                {
                    IsSuccess = false,
                    Message = "Payment not found"
                };
            }

            _mapper.Map(request, payment);

            var result = _repository.Update(payment);
            await _repository.SaveAsync();

            return new UpdatePaymentResponse
            {
                IsSuccess = result,
                Message = result ? "Payment updated successfully" : "Update failed"
            };
        }
    }
}
