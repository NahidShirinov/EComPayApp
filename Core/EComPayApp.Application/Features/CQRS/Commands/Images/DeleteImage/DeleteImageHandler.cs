using EComPayApp.Application.Features.CQRS.Commands.Products.DeleteProduct;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.DeleteImage
{
    public class DeleteImageHandler:IRequestHandler<DeleteImageCommand,DeleteImageResponse>
    {
        private readonly IWriteRepository<Image> _repository;

        public DeleteImageHandler(IWriteRepository<Image> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteImageResponse> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _repository.GetByIdAsync(request.Id);

            if (image == null)
            {
                return new DeleteImageResponse
                {
                    IsSuccess = false,
                    Message = "Image not found"
                };
            }

            var result = _repository.Remove(image);
            await _repository.SaveAsync();

            return new DeleteImageResponse
            {
                IsSuccess = result,
                Message = result ? "Image deleted successfully" : "Delete failed"
            };
        }
    }
}
