using EComPayApp.Application.Interfaces.DTO;
using System.Text.Json.Serialization;

namespace EComPayApp.Application.DTOs.FacebookDtos
{
    public class FacebookUserAccessTokenValidationDto : IDto
    {
        [JsonPropertyName("data")]
        public FacebookUserAccessTokenValidationDataDto Data  { get; set; }
    }
}
