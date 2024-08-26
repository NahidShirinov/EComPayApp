using AutoMapper;
using EComPayApp.Application.DTOs.CustomerDtos;
using EComPayApp.Application.DTOs.ImageDtos;
using EComPayApp.Application.Features.CQRS.Queries.Customer.GetCustomer;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetImageHandler:IRequestHandler<GetImageQuery,GetImageResponse>
    {
        private readonly IReadRepository<Image> _repository;
        private readonly IMapper _mapper;

        public GetImageHandler(IReadRepository<Image> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetImageResponse> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var image = await _repository.GetByIdAsync(request.Id);

            if (image == null)
            {
                return new GetImageResponse
                {
                    IsSuccess = false,
                    Message = "Image not found"
                };
            }

            var imageDto = _mapper.Map<GetImageDto>(image);

            return new GetImageResponse
            {
                IsSuccess = true,
                Image = imageDto
            };
        }
    }
}
