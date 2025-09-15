using CapstoneGeneratorAI.Domain.DTOs;
using CapstoneGeneratorAI.Domain.Interface;
using CapstoneGeneratorAI.Domain.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static CapstoneGeneratorAI.Domain.Enums.Industry;

namespace CapstoneGeneratorAI.Infrastructure.Services
{
    public class PromptApiService
    {
        private readonly HttpClient _http;
        private readonly IPromptServices _prompt;
        public PromptApiService(HttpClient http, IPromptServices prompt)
        {
            _http = http;
            _prompt = prompt;
        }
        public async Task<ResponseDTO?> AskAsync(Industry_Options industry, Project_Type type)
        {
            var prompt = _prompt.PromptAsync(industry, type);
            var payload = new
            {
                model = "llama3.2:1b",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                stream = false,
                format = new
                {
                    type = "object",
                    properties = new
                    {
                        title = new { type = "string" },
                        description = new { type = "string" },
                        features = new
                        {
                            type = "array",
                            items = new { type = "string" },

                        },
                       
                    },
                     required = new[] { "title", "description", "features" }
                }
            };
            var response = await _http.PostAsJsonAsync("http://host.docker.internal:11434/api/chat", payload);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();


            var ollamaresponse =  JsonSerializer.Deserialize<OllamaResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
           if(ollamaresponse!.Message!.content is null)
            {
                return null;
            }
            var dto = JsonSerializer.Deserialize<ResponseDTO>(ollamaresponse.Message.content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return dto;
        }
    }
}
