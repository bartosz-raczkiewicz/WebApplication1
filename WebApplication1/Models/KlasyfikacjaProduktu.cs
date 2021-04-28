using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class KlasyfikacjaProduktu
    {
        public int Id { get; set; }
        public string Nazwa_klasyfikacji { get; set; }
    }
}
