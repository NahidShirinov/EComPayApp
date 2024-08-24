using EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var writeRepository = _unitOfWork.WriteRepository<Product>();
            var product = await writeRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            writeRepository.Remove(product);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
    }
