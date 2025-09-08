using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Domain.DTOs
{
    public class ResponseDTO
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("features")]
        public List<string>? Features { get; set; }
    }
}
