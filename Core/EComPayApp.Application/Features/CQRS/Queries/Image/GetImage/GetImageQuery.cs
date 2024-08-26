using MediatR;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetImageQuery:IRequest<GetImageResponse>
    {
        public Guid Id { get; set; }

    }
}
