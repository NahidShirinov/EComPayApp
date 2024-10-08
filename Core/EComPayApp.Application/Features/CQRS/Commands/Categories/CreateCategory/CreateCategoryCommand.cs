﻿using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommand:IRequest<CreateCategoryResponse>
    {
        public string Name { get; set; }
        public ICollection<GetProductDto> Products { get; set; }
    }
}
