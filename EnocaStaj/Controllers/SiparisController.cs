using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnocaStaj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : Controller
    {
        private readonly SiparisService _siparisService;

        public SiparisController(SiparisService siparisService)
        {
            _siparisService = siparisService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSiparis([FromBody] SiparisRequest siparisRequest)
        {
            var siparis = new Siparis
            {
                FirmaId = siparisRequest.FirmaId,
                UrunId = siparisRequest.UrunId,
                SiparisVerenKisiAdi = siparisRequest.SiparisVerenKisiAdi,
                SiparisTarihi = siparisRequest.SiparisTarihi
            };

            var result = await _siparisService.CreateSiparisAsync(siparis, siparisRequest.SiparisTarihi);
            if (result == "Sipariş başarıyla oluşturuldu.")
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }

    public class SiparisRequest
    {
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public string SiparisVerenKisiAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }
    }
}
