using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Siparis
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public string SiparisVerenKisiAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public Firma Firma { get; set; }
        public Urun Urun { get; set; }
    }
}
