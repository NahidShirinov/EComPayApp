using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.AboutDtos
{
    public class UpdateAboutDto : IDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
    }
}
