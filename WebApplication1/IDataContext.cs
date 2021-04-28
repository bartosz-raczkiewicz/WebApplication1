using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public interface IDataContext
    {
        DbSet<GrupaProduktu> GrupaProduktu { get; set; }
        DbSet<PodGrupaProduktu> PodGrupaProduktu { get; set; }
        DbSet<KlasyfikacjaProduktu> KlasyfikacjaProduktu { get; set; }
        DbSet<Produkt> Produkt { get; set; }
        DbSet<Oferta> Oferta { get; set; }
        DbSet<Oferta_Produktu> Oferta_Produktu { get; set; }
    }
}