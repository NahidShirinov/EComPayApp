using EComPayApp.Application.DTOs.AboutDtos;
using EComPayApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComPayApp.Application.Features.CQRS.Queries.About.GetAbout
{
    public class GetAboutHandler : IRequestHandler<GetAboutQuery, GetAboutResponse>
    {
        private readonly IReadRepository<EComPayApp.Domain.Entities.About> _aboutRepository;

        public GetAboutHandler(IReadRepository<EComPayApp.Domain.Entities.About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<GetAboutResponse> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var about = await _aboutRepository.GetByIdAsync(request.Id);

            if (about == null)
            {
                return new GetAboutResponse
                {
                    IsSuccess = false,
                    Message = "About not found"
                };
            }

            var aboutDto = new GetAboutDto
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                Vision = about.Vision,
                Mission = about.Mission
            };

            return new GetAboutResponse
            {
                IsSuccess = true,
                About = aboutDto
            };
        }
    
    }
}
