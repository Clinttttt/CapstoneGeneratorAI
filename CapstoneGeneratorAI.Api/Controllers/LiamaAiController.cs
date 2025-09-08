using CapstoneGeneratorAI.Domain.DTOs;
using CapstoneGeneratorAI.Domain.Entities;
using CapstoneGeneratorAI.Domain.Interface;
using CapstoneGeneratorAI.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using static CapstoneGeneratorAI.Domain.Enums.Industry;

namespace CapstoneGeneratorAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiamaAiController : ControllerBase
    {
        private readonly HttpClient _http;
       
        private readonly PromptApiService _promptApi;
        public LiamaAiController(IHttpClientFactory factory, PromptApiService promptApi)
        {
            _http = factory.CreateClient();
            _http.Timeout = TimeSpan.FromMinutes(5);
         
            _promptApi = promptApi;
        }

        [HttpPost("Ask")]
        public async Task<ActionResult<ResponseDTO>> AskAsync([FromBody] RequestDTO request)
        {
            var response = await _promptApi.AskAsync(request.industry, request.type);
            if(response is null)
            {
                return BadRequest("empty");
            }
            return Ok(response);
        }
    }
}
