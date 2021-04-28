using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Oferta_Produktu
    {
        public int Id_oferty { get; set; }
        public virtual Oferta Oferta { get; set; }
        public int Id_produktu { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int Liczba_sztuk { get; set; }
        public decimal Upust_Procentowy { get; set; }
    }
}
