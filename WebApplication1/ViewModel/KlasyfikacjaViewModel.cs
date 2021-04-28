using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class KlasyfikacjaViewModel
    {
        public KlasyfikacjaViewModel(List<GrupaViewModel> grupaViewModels)
        {
            GrupaViewModels = grupaViewModels;
        }

        public List<GrupaViewModel> GrupaViewModels { get; }
        public decimal PrzedUpustem => GrupaViewModels.Sum(x => x.PrzedUpustem);
        public decimal PoUpuscie => GrupaViewModels.Sum(x => x.PoUpuscie);
    }
}
