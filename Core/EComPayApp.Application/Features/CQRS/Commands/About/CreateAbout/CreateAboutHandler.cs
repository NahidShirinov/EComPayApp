using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Commands.About.CreateAbout
{
    public class CreateAboutHandler : IRequestHandler<CreateAboutCommand, CreateAboutResponse>
    {
        private readonly IWriteRepository<EComPayApp.Domain.Entities.About> _aboutRepository;

        public CreateAboutHandler(IWriteRepository<EComPayApp.Domain.Entities.About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<CreateAboutResponse> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = new EComPayApp.Domain.Entities.About
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Vision = request.Vision,
                Mission = request.Mission
            };

            await _aboutRepository.AddAsync(about);

            return new CreateAboutResponse
            {
                IsSuccess = true,
                AboutId = about.Id,
                Message = "About created successfully"
            };
        }
    
    }
}
