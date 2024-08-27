using EComPayApp.Application.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Branches.UpdateBranch
{
    public class UpdateBranchResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetBranchDto Branch { get; set; }
    }
}
