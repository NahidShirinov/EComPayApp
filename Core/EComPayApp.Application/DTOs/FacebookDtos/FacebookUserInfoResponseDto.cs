using EComPayApp.Application.Interfaces.DTO;
using System.Text.Json.Serialization;

namespace EComPayApp.Application.DTOs.FacebookDtos
{
    public class FacebookUserInfoResponseDto : IDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("name")]

        public string Name { get; set; }
    }
}
