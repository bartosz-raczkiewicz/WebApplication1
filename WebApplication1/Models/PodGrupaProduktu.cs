using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PodGrupaProduktu
    {
        public int Id { get; set; }
        public int ID_GrupyProduktu { get; set; }
        public virtual GrupaProduktu GrupaProduktu { get; set; }
        public string Nazwa { get; set; }
    }
}
