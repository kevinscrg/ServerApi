using Microsoft.AspNetCore.Mvc;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.ReceznieDtos;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenziiController : ControllerBase
    {
       private readonly IRecenzieService _recenzieService;

        public RecenziiController(IRecenzieService recenzieService)
        {
            _recenzieService = recenzieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecenzieDto>>> GetRecenzii()
        {
            var recenzii = await _recenzieService.GetAllRecenziiAsync();
            return Ok(recenzii);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecenzieDto>> GetRecenzie(int id)
        {
            var recenzie = await _recenzieService.GetRecenzieByIdAsync(id);
            if (recenzie == null)
            {
                return NotFound();
            }
            return Ok(recenzie);
        }

        [HttpPost]
        public async Task<ActionResult<RecenzieDto>> CreateRecenzie(CreateRecenzieDto recenzie)
        {
            var recenzieAdded = await _recenzieService.AddRecenzieAsync(recenzie);
            return CreatedAtAction(nameof(GetRecenzie), new { id = recenzieAdded.Id }, recenzieAdded);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecenzie(int id, UpdateRecenzieDto recenzie)
        {
            try { 
            if (id != recenzie.Id)
            {
                return BadRequest();
            }

            await _recenzieService.UpdateRecenzieAsync(recenzie);

            return NoContent();
            }catch(System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecenzie(int id)
        {
            await _recenzieService.DeleteRecenzieAsync(id);
            return NoContent();
        }
    }
}
