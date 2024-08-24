using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid> // Guid olaraq dəyişdirildi
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(), // Yeni bir GUID təyin edildi
                Name = request.Name,
                Price = (float)request.Price
                // Digər xassələri təyin edin
            };

            var writeRepository = _unitOfWork.WriteRepository<Product>();
            await writeRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return product.Id; // Id artıq Guid olaraq
        }
    }
}
