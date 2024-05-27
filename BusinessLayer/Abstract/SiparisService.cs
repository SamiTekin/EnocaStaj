using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public class SiparisService
    {
        private readonly IRepository<Siparis> _siparisRepository;
        private readonly IRepository<Firma> _firmaRepository;
        private readonly IRepository<Urun> _urunRepository;

        public SiparisService(IRepository<Siparis> siparisRepository, IRepository<Firma> firmaRepository, IRepository<Urun> urunRepository)
        {
            _siparisRepository = siparisRepository;
            _firmaRepository = firmaRepository;
            _urunRepository = urunRepository;
        }

        public async Task<string> CreateSiparisAsync(Siparis siparis, DateTime siparisZamani)
        {
            var firma = await _firmaRepository.GetByIdAsync(siparis.FirmaId);
            if (firma == null)
            {
                return "Firma bulunamadı.";
            }

            if (!firma.OnayDurumu)
            {
                return "Firma onaylı değil.";
            }

            var izinBaslangicSaati = DateTime.Today.Add(firma.SiparisIzinBaslangicSaati);
            var izinBitisSaati = DateTime.Today.Add(firma.SiparisIzinBitisSaati);

            if (siparisZamani < izinBaslangicSaati || siparisZamani > izinBitisSaati)
            {
                return "Firma şu an sipariş almıyor.";
            }

            var urun = await _urunRepository.GetByIdAsync(siparis.UrunId);
            if (urun == null || urun.FirmaId != firma.Id)
            {
                return "Ürün bulunamadı veya firmaya ait değil.";
            }

            await _siparisRepository.AddAsync(siparis);
            await _siparisRepository.SaveChangesAsync();

            return "Sipariş başarıyla oluşturuldu.";
        }
    
}
}
