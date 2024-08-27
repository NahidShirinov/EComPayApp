using EComPayApp.Application.DTOs.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Branches.CreateBranch
{
    public class CreateBranchResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public GetAddressDto Branch { get; set; }

    }
}
