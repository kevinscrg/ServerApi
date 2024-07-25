using Microsoft.AspNetCore.Mvc;
using ServerApi.Dtos.CarteDtos;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartiController : ControllerBase
    {
        private readonly ICarteService _carteService;

        public CartiController(ICarteService carteService)
        {
            _carteService = carteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarteDto>>> GetCarti()
        {
           try{ 
                var carti = await _carteService.GetAllCartiAsync();
                return Ok(carti);
            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarteDto>> GetCarte(int id)
        {
            try{
            var carte = await _carteService.GetCarteByIdAsync(id);
            if (carte == null)
            {
                return NotFound();
            }
                return Ok(carte);
            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarteDto>> CreateCarte(CreateCarteDto carte)
        {
            try{           
                var carteAdded = await _carteService.AddCarteAsync(carte);
                return CreatedAtAction(nameof(GetCarte), new { id = carteAdded.Id }, carteAdded);
            }catch(System.Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarte(int id, UpdateCarteDto carte)
        {
            try
            {
                if (id != carte.Id)
                {
                    return BadRequest();
                }

                await _carteService.UpdateCarteAsync(carte);

                return NoContent();
            }catch(System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarte(int id)
        {
            try{
                await _carteService.DeleteCarteAsync(id);
                return NoContent();
            }catch(System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
