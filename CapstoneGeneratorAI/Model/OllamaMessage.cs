using CapstoneGeneratorAI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Domain.Model
{
    public class OllamaResponse
    {
        [JsonPropertyName("message")]
        public OllamaMessage? Message  { get; set; }
    }
    public class OllamaMessage
    {
        [JsonPropertyName("content")]
        public string? content { get; set; }
    }
}
