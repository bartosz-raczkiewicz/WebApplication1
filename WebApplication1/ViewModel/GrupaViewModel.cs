using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.ViewModel
{
    public class GrupaViewModel
    {
        public GrupaViewModel(List<PodGrupaProduktuViewModel> podGrupaProduktuViewModels)
        {
            PodGrupaProduktuViewModels = podGrupaProduktuViewModels;
        }

        public List<PodGrupaProduktuViewModel> PodGrupaProduktuViewModels { get; set; }
        public decimal PrzedUpustem => PodGrupaProduktuViewModels.Sum(x => x.PrzedUpustem);
        public decimal PoUpuscie => PodGrupaProduktuViewModels.Sum(x => x.PoUpuscie);
    }
}