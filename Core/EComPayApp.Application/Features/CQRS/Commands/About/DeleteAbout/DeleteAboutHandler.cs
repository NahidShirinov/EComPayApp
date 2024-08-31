using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.About.DeleteAbout
{
    public class DeleteAboutHandler : IRequestHandler<DeleteAboutCommand, DeleteAboutResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.About> _aboutRepository;

        public DeleteAboutHandler(IWriteRepository<EComPayApp.Domain.Entities.About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<DeleteAboutResponse> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _aboutRepository.GetByIdAsync(request.Id);

            if (about == null)
            {
                return new DeleteAboutResponse
                {
                    IsSuccess = false,
                    Message = "About not found"
                };
            }

            await _aboutRepository.DeleteAsync(about);

            return new DeleteAboutResponse
            {
                IsSuccess = true,
                Message = "About deleted successfully"
            };
        }
    
    }
}
