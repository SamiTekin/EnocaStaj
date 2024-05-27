using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Urun
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public string Adi { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }
        public Firma Firma { get; set; }
    }
}
