using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Oferta
    {
        public int ID { get; set; }
        public DateTime DataUtworzenia { get; set; }
        public string Autor { get; set; }
        public string Opis { get; set; }
    }
}
