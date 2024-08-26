using AutoMapper;
using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Application.Interfaces.Repositories;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IReadRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductHandler(IReadRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return new GetProductResponse
                {
                    IsSuccess = false,
                    Message = "Product not found"
                };
            }

            var productDto = _mapper.Map<GetProductDto>(product);

            return new GetProductResponse
            {
                IsSuccess = true,
                Product = productDto
            };
        }
    }
}