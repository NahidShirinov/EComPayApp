using EComPayApp.Application.DTOs.AddressDtos;
using EComPayApp.Application.DTOs.BranchDtos;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetBranchResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetBranchDto Branch { get; set; }
    }
}
