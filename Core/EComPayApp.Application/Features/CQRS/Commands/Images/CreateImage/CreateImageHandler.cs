using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Products.CreateProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.CreateImage
{
    public class CreateImageHandler:IRequestHandler<CreateImageCommand,CreateImageResponse>
    {
        private readonly IWriteRepository<Image> _repository;
        private readonly IMapper _mapper;

        public CreateImageHandler(IWriteRepository<Image> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateImageResponse> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<Image>(request);

            var result = await _repository.AddAsync(image);
            await _repository.SaveAsync();

            return new CreateImageResponse
            {
                IsSuccess = result,
                Message = result ? "Image created successfully" : "Creation failed"
            };
        }
    }
}
