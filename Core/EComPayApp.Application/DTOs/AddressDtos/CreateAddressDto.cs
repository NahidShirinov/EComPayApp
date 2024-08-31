using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.AddressDtos
{
    public class CreateAddressDto : IDto
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
