using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Firma
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool OnayDurumu { get; set; }
        public TimeSpan SiparisIzinBaslangicSaati { get; set; }
        public TimeSpan SiparisIzinBitisSaati { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
