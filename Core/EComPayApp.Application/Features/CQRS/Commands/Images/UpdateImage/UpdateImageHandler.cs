using AutoMapper;
using EComPayApp.Application.Features.CQRS.Commands.Products.UpdateProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.UpdateImage
{
    public class UpdateImageHandler:IRequestHandler<UpdateImageCommand,UpdateImageResponse>
    {
        private readonly IWriteRepository<Image> _repository;
        private readonly IMapper _mapper;

        public UpdateImageHandler(IWriteRepository<Image> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateImageResponse> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _repository.GetByIdAsync(request.Id);

            if (image == null)
            {
                return new UpdateImageResponse
                {
                    IsSuccess = false,
                    Message = "Image not found"
                };
            }

            _mapper.Map(request, image);

            var result = _repository.Update(image);
            await _repository.SaveAsync();

            return new UpdateImageResponse
            {
                IsSuccess = result,
                Message = result ? "Image updated successfully" : "Update failed"
            };
        }
    }
}
