using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DataContext : DbContext, IDataContext
    {
        public virtual DbSet<GrupaProduktu> GrupaProduktu { get; set; }
        public virtual DbSet<PodGrupaProduktu> PodGrupaProduktu { get; set; }
        public virtual DbSet<KlasyfikacjaProduktu> KlasyfikacjaProduktu { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Oferta_Produktu> Oferta_Produktu { get; set; }

    }
}
