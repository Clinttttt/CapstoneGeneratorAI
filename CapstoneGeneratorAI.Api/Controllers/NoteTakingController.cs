using CapstoneGeneratorAI.Domain.DTOs;
using CapstoneGeneratorAI.Domain.Entities;
using CapstoneGeneratorAI.Domain.Interface;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneGeneratorAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteTakingController(INoteTakingServices noteTaking) : ControllerBase
    {
        [HttpPost("CreateRecord")]
        public async Task<ActionResult<NoteTaking>> CreateRecordAsync(NoteTakingDTO data)
        {
            var response = await noteTaking.RecordNoteAsync(data);
            if(response is null)
            {
                return BadRequest("Something went wrong");
            }
            var filter = response.Adapt<NoteTakingDTO>();
            return Ok(filter);
        }
        [HttpGet("GetAllRecord")]
        public async Task<IActionResult> GetAllRecordAsync()
        {
            var response = await noteTaking.GetAllRecord();
            if(response is null)
            {
                return BadRequest("Empty Data");
            }
            return Ok(response);
        }
        [HttpGet("GetARecord/{Id}")]
        public async Task<ActionResult<NoteTakingDTO>> GetRecordAsync( int Id)
        {
            var response = await noteTaking.GetRecordAsync(Id);
            if(response is null)
            {
                return BadRequest("Nothing to Retrieve");
            }
            return Ok(response);
        }
        [HttpDelete("DeleteRecord/{Id}")]
        public async Task<ActionResult<bool>> DeleteRecord( int Id)
        {
            var response = await noteTaking.DeleteRecordAsync(Id);
            if(response is false)
            {
                return BadRequest("Nothong to delete");
            }
            return Ok(response);
        }

    }
}
