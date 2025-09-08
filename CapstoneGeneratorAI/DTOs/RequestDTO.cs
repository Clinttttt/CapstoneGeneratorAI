using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CapstoneGeneratorAI.Domain.Enums.Industry;

namespace CapstoneGeneratorAI.Domain.DTOs
{
   public class RequestDTO
    {

        [JsonPropertyName("industry")]
        public Industry_Options industry { get; set; }

        [JsonPropertyName("type")]
        public Project_Type type { get; set; }
    }
}
