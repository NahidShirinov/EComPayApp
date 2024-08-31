using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.AboutDtos
{
    public class CreateAboutDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
    }
}
