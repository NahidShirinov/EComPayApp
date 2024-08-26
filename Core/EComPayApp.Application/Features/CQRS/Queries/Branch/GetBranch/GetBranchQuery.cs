using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries
{
    public class GetBranchQuery:IRequest<GetBranchResponse>
    {
        public Guid Id { get; set; }
        public GetBranchQuery(Guid id)
        {
            Id = id;
        }
    }
}
