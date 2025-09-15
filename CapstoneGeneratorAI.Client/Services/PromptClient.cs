using CapstoneGeneratorAI.Domain.DTOs;
using System.Text.Json;
using static CapstoneGeneratorAI.Domain.Enums.Industry;

namespace CapstoneGeneratorAI.Client.Services
{
    public class PromptClient
    {
        private readonly HttpClient _http;
        public PromptClient (IHttpClientFactory clientFactory)
        {
            _http = clientFactory.CreateClient();
        }
        public async Task<ResponseDTO?> AskAsync(RequestDTO request)
        {
            var response = await _http.PostAsJsonAsync("https://host.docker.internal:7094/api/LiamaAi/Ask", request);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<ResponseDTO>();

        }
    }
}
