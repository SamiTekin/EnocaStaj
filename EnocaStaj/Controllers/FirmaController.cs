using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnocaStaj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : Controller
    {
        private readonly FirmaService _firmaService;

        public FirmaController(FirmaService firmaService)
        {
            _firmaService = firmaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFirmalar()
        {
            var firmalar = await _firmaService.GetAllFirmalarAsync();
            return Ok(firmalar);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFirma(int id)
        {
            var firma = await _firmaService.GetFirmaByIdAsync(id);
            if (firma == null)
            {
                return NotFound();
            }
            return Ok(firma);
        }

        [HttpPost]
        public async Task<IActionResult> AddFirma([FromBody] Firma firma)
        {
            await _firmaService.AddFirmaAsync(firma);
            return CreatedAtAction(nameof(GetFirma), new { id = firma.Id }, firma);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFirma(int id, [FromBody] Firma firma)
        {
            if (id != firma.Id)
            {
                return BadRequest();
            }

            await _firmaService.UpdateFirmaAsync(firma);
            return NoContent();
        }

    }
}
