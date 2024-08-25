using MediatR;

namespace EComPayApp.Application.Features.CQRS.Commands.Branches.UpdateBranch
{
    public class UpdateBranchCommand:IRequest<UpdateBranchResponse>
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
