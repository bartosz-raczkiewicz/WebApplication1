using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena_jednostkowa { get; set; }
        public int Id_PogrupyProduktu { get; set; }
        public virtual PodGrupaProduktu PodGrupaProduktu { get; set; }
        public int Id_KlasyfikacjiProduktu { get; set; }
        public virtual KlasyfikacjaProduktu KlasyfikacjaProduktu { get; set; }
    }
}
