using EComPayApp.Application.Interfaces.DTO;
using System.Text.Json.Serialization;

namespace EComPayApp.Application.DTOs.FacebookDtos
{
    public class FacebookUserAccessTokenValidationDataDto : IDto
    {
        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
