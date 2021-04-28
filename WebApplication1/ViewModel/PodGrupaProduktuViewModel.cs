using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.ViewModel
{
    public class PodGrupaProduktuViewModel
    {
        public PodGrupaProduktuViewModel(List<ProduktViewModel> produktViewModels)
        {
            ProduktViewModel = produktViewModels;
        }

        public List<ProduktViewModel> ProduktViewModel { get; set; }
        public decimal PrzedUpustem => ProduktViewModel.Sum(x => x.PrzedUpustem);
        public decimal PoUpuscie => ProduktViewModel.Sum(x => x.PrzedUpustem);
    }
}