﻿using EComPayApp.Application.DTOs.BranchDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<UpdateAddressResponse>
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public ICollection<GetBranchDto> Branches { get; set; }

    }
}
