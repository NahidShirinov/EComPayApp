using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.ContactDtos
{
    public class UpdateContactDto : IDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WorkingHours { get; set; }
        public string MapLocation { get; set; }

    }
}
