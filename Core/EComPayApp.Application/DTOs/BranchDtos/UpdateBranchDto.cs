using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Application.Interfaces.DTO;

namespace EComPayApp.Application.DTOs.BranchDtos
{
    public class UpdateBranchDto : IDto
    {
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public ICollection<GetProductDto> Products { get; set; }

}
}
