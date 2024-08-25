using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.UpdateImage
{
    public class UpdateImageCommand:IRequest<UpdateImageResponse>
    {
        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
    }
}
