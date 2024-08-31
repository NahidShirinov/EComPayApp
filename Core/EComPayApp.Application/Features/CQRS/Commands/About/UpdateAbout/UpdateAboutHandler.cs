using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.About.UpdateAbout
{
    public class UpdateAboutHandler : IRequestHandler<UpdateAboutCommand, UpdateAboutResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.About> _aboutRepository;

        public UpdateAboutHandler(IWriteRepository<EComPayApp.Domain.Entities.About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<UpdateAboutResponse> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _aboutRepository.GetByIdAsync(request.Id);

            if (about == null)
            {
                return new UpdateAboutResponse
                {
                    IsSuccess = false,
                    Message = "About not found"
                };
            }

            about.Title = request.Title;
            about.Description = request.Description;
            about.Vision = request.Vision;
            about.Mission = request.Mission;

            await _aboutRepository.UpdateAsync(about);

            return new UpdateAboutResponse
            {
                IsSuccess = true,
                Message = "About updated successfully"
            };
        }
    
    }
}
