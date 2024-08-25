using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.DeleteImage
{
    public class DeleteImageCommand:IRequest<DeleteImageResponse>
    {
        public Guid Id { get; set; }

    }
}
