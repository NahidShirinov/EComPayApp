﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Contact.DeleteContact
{
    public class DeleteContactCommand : IRequest<DeleteContactResponse>
    {
        public Guid Id { get; set; }

       
    }
}
