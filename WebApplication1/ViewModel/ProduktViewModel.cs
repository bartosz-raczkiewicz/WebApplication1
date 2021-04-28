using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class ProduktViewModel
    {
        public ProduktViewModel(Produkt produkt, Oferta_Produktu ofertaProduktu)
        {
            Sztuki = ofertaProduktu.Liczba_sztuk;
            Cena = produkt.Cena_jednostkowa;
            Nazwa = produkt.Nazwa;
            Upust = ofertaProduktu.Upust_Procentowy;
        }

        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Sztuki { get; set; }
        public decimal Upust { get; set; }

        public decimal PrzedUpustem => Sztuki * Cena;
        public decimal PoUpuscie => PrzedUpustem - PrzedUpustem * Upust / 100;
    }
}