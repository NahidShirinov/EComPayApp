using EComPayApp.Domain.Entities;
using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Images.CreateImage
{
    public class CreateImageCommand:IRequest<CreateImageResponse>
    {
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
    }
}
