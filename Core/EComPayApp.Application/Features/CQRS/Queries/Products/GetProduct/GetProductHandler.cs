using EComPayApp.Application.DTOs.ProductDtos;
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
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var readRepository = _unitOfWork.ReadRepository<Product>();

            // Məhsulu ID ilə əldə et
            var product = await readRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            // Məhsulu DTO-ya xəritələndir
            return new GetProductDto
            {
                
                Name = product.Name,
                Price = product.Price
            };
        }
    }
    
    }
